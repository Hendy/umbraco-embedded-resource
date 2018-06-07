using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Umbraco.Core;

namespace Our.Umbraco.EmbeddedResource
{
    internal static class EmbeddedResourceService
    {
        /// <summary>
        /// Gets the full dataset of registered emebedded resource POCOs (either from cache, or by reflecting for assembly attributes)
        /// </summary>
        /// <returns>POCO array of all registered emebedded resources</returns>
        internal static EmbeddedResourceItem[] GetEmbeddedResourceItems()
        {
            var embeddedResourceItems = new List<EmbeddedResourceItem>(); // the return value

            // TODO: add caching here to avoid attribute relfection

            // for each of the attributes, get the resrouce & the url it should be served on, and put this table data somewhere
            foreach (var assembly in EmbeddedResourceService.GetAssemblies())
            {
                foreach (var attribute in assembly.GetCustomAttributes<EmbeddedResourceAttribute>())
                {
                    // check to see if resource namespace exists
                    if (assembly.GetManifestResourceNames().Any(x => x == attribute.ResourceNamespace))
                    {
                        embeddedResourceItems.Add(new EmbeddedResourceItem(assembly.FullName, attribute.ResourceNamespace, attribute.ResourceUrl));
                    }
                }
            }

            return embeddedResourceItems.ToArray();
        }

        /// <summary>
        /// Returns true if the supplied url maps to an embedded resource
        /// </summary>
        /// <param name="url">Either the full url (that can be converted to app relative) or an app relative url</param>
        /// <returns></returns>
        internal static bool ResourceExists(string url)
        {
            url = EmbeddedResourceService.EnsureUrlAppRelative(url);

            // check in collection of embedded resource items to see if this url has been registered
            return EmbeddedResourceService.GetEmbeddedResourceItems().Any(x => x.ResourceUrl == url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">Either the full url (that can be converted to app relative) or an app relative url</param>
        /// <returns>a stream or null</returns>
        internal static Stream GetResourceStream(string url)
        {
            url = EmbeddedResourceService.EnsureUrlAppRelative(url);

            var embeddedResourceItem = EmbeddedResourceService.GetEmbeddedResourceItems().SingleOrDefault(x => x.ResourceUrl == url);

            if (embeddedResourceItem != null)
            {
                var assembly = EmbeddedResourceService
                                .GetAssemblies()
                                .Single(x => x.FullName.InvariantEquals(embeddedResourceItem.AssemblyFullName)); // expected to exist

                var resourceName = assembly
                                    .GetManifestResourceNames()
                                    .FirstOrDefault(x => x.InvariantEquals(embeddedResourceItem.ResourceNamespace));

                if (resourceName != null)
                {
                    return assembly.GetManifestResourceStream(resourceName);
                }
            }

            return null;
        }

        /// <summary>
        /// single collection of assemblies that contain registered embedded resources
        /// </summary>
        /// <returns></returns>
        private static Assembly[] GetAssemblies()
        {
            // TODO: add caching here
            return AppDomain
                    .CurrentDomain
                    .GetAssemblies()
                    .Where(x => x.GetCustomAttributes<EmbeddedResourceAttribute>().Any())
                    .ToArray();
        }

        /// <summary>
        /// Helper to ensure that any urls supplied are converted to app relative urls (if possible)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string EnsureUrlAppRelative(string url)
        {            
            if (HttpContext.Current != null) // if outside of the unit test context
            {
                if (!VirtualPathUtility.IsAppRelative(url))
                {
                    url = VirtualPathUtility.ToAppRelative(url);
                }
            }

            return url;
        }
    }
}