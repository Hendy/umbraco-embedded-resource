using Our.Umbraco.EmbeddedResource.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Logging;

namespace Our.Umbraco.EmbeddedResource
{
    internal static class EmbeddedResourceService
    {
        /// <summary>
        /// Builds an array of POCOs to represent the consumer attributes found (any conflicts are excluded, for example, can't
        /// extract two resources to the same file, or serve different resources on the samme url)
        /// </summary>
        /// <returns>POCO array of all registered emebedded resources</returns>
        internal static EmbeddedResourceItem[] GetEmbeddedResourceItems()
        {
            var embeddedResourceItems = new List<EmbeddedResourceItem>();

            foreach (var assembly in EmbeddedResourceService.GetAssemblies())
            {
                var attributes = ((IEmbeddedResourceAttribute[])assembly.GetCustomAttributes<EmbeddedResourceAttribute>())
                                .Union((IEmbeddedResourceAttribute[])assembly.GetCustomAttributes<EmbeddedResourceProtectedAttribute>())
                                .Union((IEmbeddedResourceAttribute[])assembly.GetCustomAttributes<EmbeddedResourceExtractAttribute>());

                foreach (var attribute in attributes)
                {                    
                    if (!assembly.GetManifestResourceNames().Any(x => x == attribute.ResourceNamespace))
                    {
                        LogHelper.Warn(typeof(EmbeddedResourceService), $"Embedded Resource: '{ attribute.ResourceNamespace }', not found in Assembly: '{ assembly.FullName }'");
                    }
                    else
                    {
                        var url = EmbeddedResourceService.EnsureUrlAppRelative(attribute.ResourceUrl);

                        if (url == null)
                        { 
                            LogHelper.Warn(typeof(EmbeddedResourceService), $"Invalid Relative Url: '{ attribute.ResourceUrl }'");
                        }
                        else
                        {
                            var backOfficeUserOnly = attribute is EmbeddedResourceProtectedAttribute;
                            var extractToFileSystem = attribute is EmbeddedResourceExtractAttribute;

                            /// there should only be a max possible 1 conflict, as conflicting items don't get added to this list
                            var conflict = embeddedResourceItems.SingleOrDefault(x => x.ExtractToFileSystem == extractToFileSystem && x.ResourceUrl == url);

                            if (conflict != null) 
                            {
                                LogHelper.Warn(typeof(EmbeddedResourceService),
                                    $"Conflict with existing registration: (Resource: '{conflict.ResourceNamespace}', Url: '{conflict.ResourceUrl}') " +
                                    $"When trying to register (Resource: '{attribute.ResourceNamespace}', Url: '{url}') ");
                            }
                            else // no conflict
                            {
                                // single creation point of item models
                                embeddedResourceItems.Add(
                                    new EmbeddedResourceItem(
                                        assembly.FullName,
                                        attribute.ResourceNamespace,
                                        url,
                                        backOfficeUserOnly,
                                        extractToFileSystem));
                            }
                        }
                    }
                }
            }

            return embeddedResourceItems.ToArray();
        }

        /// <summary>
        /// Attempt to get resource item that will be serveed on a url, by url (ignores any registrations for extracting to file system)
        /// </summary>
        /// <param name="url"></param>
        /// <returns>the embedded resource item or null</returns>
        internal static EmbeddedResourceItem GetServedEmbeddedResourceItem(string url)
        {
            url = EmbeddedResourceService.EnsureUrlAppRelative(url);

            if (url != null)
            {
                return EmbeddedResourceService
                            .GetEmbeddedResourceItems()
                            .Where(x => !x.ExtractToFileSystem)
                            .SingleOrDefault(x => x.ResourceUrl == url);
            }

            return null;
        }

        /// <summary>
        /// Returns true if the supplied url maps to an embedded resource
        /// </summary>
        /// <param name="url">Either the full url (that can be converted to app relative) or an app relative url</param>
        /// <returns></returns>
        internal static bool ServedResourceExists(string url)
        {
            return EmbeddedResourceService.GetServedEmbeddedResourceItem(url) != null; // TODO: ignore the extraction one
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">Either the full url (that can be converted to app relative) or an app relative url</param>
        /// <returns>a stream or null</returns>
        internal static Stream GetServedResourceStream(string url)
        {
            return EmbeddedResourceService.GetResourceStream(EmbeddedResourceService.GetServedEmbeddedResourceItem(url));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="embeddedResourceItem"></param>
        /// <returns></returns>
        internal static Stream GetResourceStream(EmbeddedResourceItem embeddedResourceItem)
        {
            if (embeddedResourceItem != null)
            {
                var assembly = EmbeddedResourceService
                                .GetAssemblies()
                                .Single(x => x.FullName == embeddedResourceItem.AssemblyFullName); // expected to exist

                var resourceName = assembly
                                    .GetManifestResourceNames()
                                    .FirstOrDefault(x => x == embeddedResourceItem.ResourceNamespace);

                if (resourceName != null)
                {
                    return assembly.GetManifestResourceStream(resourceName);
                }
            }

            return null;
        }

        internal static void ExtractToFileSystem(EmbeddedResourceItem embeddedResourceItem)
        {

        }

        /// <summary>
        /// get all assemblies that contain any of the attributes
        /// </summary>
        /// <returns></returns>
        private static Assembly[] GetAssemblies()
        {
            return AppDomain
                    .CurrentDomain
                    .GetAssemblies()
                    .Where(x => 
                        x.GetCustomAttributes<EmbeddedResourceAttribute>().Any() || 
                        x.GetCustomAttributes<EmbeddedResourceProtectedAttribute>().Any() ||
                        x.GetCustomAttributes< EmbeddedResourceExtractAttribute>().Any())
                    .ToArray();
        }

        /// <summary>
        /// Helper to ensure that any urls supplied are converted to app relative urls (prefixed wtih "~/"), otherwise returns null
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string EnsureUrlAppRelative(string url)
        {            
            if (HttpContext.Current != null) // if outside of the unit test context
            {
                if (!VirtualPathUtility.IsAppRelative(url))
                {
                    return VirtualPathUtility.ToAppRelative(url);
                }

                return url;
            }
            else if (Uri.IsWellFormedUriString(url, UriKind.Relative))
            {
                return "~" + url.TrimStart('~'); // ensure it's returned with tide prefix
            }

            return null;
        }
    }
}