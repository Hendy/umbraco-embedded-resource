using ClientDependency.Core;
using Our.Umbraco.EmbeddedResource.ClientDependency;
using Our.Umbraco.EmbeddedResource.Interfaces;
using Our.Umbraco.EmbeddedResource.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Security;

namespace Our.Umbraco.EmbeddedResource.Services
{
    internal class EmbeddedResourceService
    {
        private HttpContextBase _httpContext;

        //private HttpContextBase HttpContext => _httpContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        internal EmbeddedResourceService(HttpContextBase httpContext = null)
        {
            this._httpContext = httpContext;
        }

        /// <summary>
        /// Look for all attributes and build the data-set
        /// </summary>
        /// <param name="httpContext"></param>
        internal void RegisterResources()
        {
            //locking required here

            foreach (var embeddedResourceItem in this.GetAllEmbeddedResourceItems())
            {
                if (embeddedResourceItem.ExtractToFileSystem)
                {
                    this.ExtractToFileSystem(embeddedResourceItem);
                }
                else
                { 
                    RouteTable
                        .Routes
                        .MapRoute(
                            name: "EmbeddedResource" + Guid.NewGuid().ToString(),
                            url: embeddedResourceItem.ResourceUrl.TrimStart("~/"), // forward slash always expected
                            defaults: new
                            {
                                controller = "EmbeddedResource",
                                action = "GetEmbeddedResource",
                                url = embeddedResourceItem.ResourceUrl
                            },
                            namespaces: new[] { "Our.Umbraco.EmbeddedResource.Controllers" });

                    // register with client depenedency
                    FileWriters.AddWriterForFile(embeddedResourceItem.ResourceUrl.TrimStart('~'), new EmbeddedResourceVirtualFileWriter(this));
                }
            }
        }

        /// <summary>
        /// Builds an array of POCOs to represent the all consumer attributes found (excludes any conflicts - two different resources to the same file or url)
        /// </summary>
        /// <returns>POCO array of all registered emebedded resources</returns>
        internal EmbeddedResourceItem[] GetAllEmbeddedResourceItems()
        {
            var embeddedResourceItems = new List<EmbeddedResourceItem>();

            // TODO: add caching, as called at least twice at the moment

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

                            // check this doesn't conflict with any already added
                            var conflict = embeddedResourceItems
                                            .SingleOrDefault(x => x.ExtractToFileSystem == extractToFileSystem && x.ResourceUrl == url);

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
        internal EmbeddedResourceItem GetServedEmbeddedResourceItem(string url)
        {
            url = EmbeddedResourceService.EnsureUrlAppRelative(url);

            if (url != null)
            {
                return this
                        .GetAllEmbeddedResourceItems()
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
        internal bool ServedResourceExists(string url)
        {
            return this.GetServedEmbeddedResourceItem(url) != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">Either the full url (that can be converted to app relative) or an app relative url</param>
        /// <returns>a stream or null</returns>
        internal Stream GetServedResourceStream(string url)
        {
            return this.GetResourceStream(this.GetServedEmbeddedResourceItem(url));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="embeddedResourceItem">the details of the resource to extract</param>
        internal void ExtractToFileSystem(EmbeddedResourceItem embeddedResourceItem)
        {
            if (!embeddedResourceItem.ExtractToFileSystem)
            {
                LogHelper.Warn(typeof(EmbeddedResourceService), $"This should never happen - attempting to extract resource '{embeddedResourceItem.ResourceNamespace}' not marked for extraction");
            }
            else
            {
                var path = this._httpContext.Server.MapPath(embeddedResourceItem.ResourceUrl);

                if (File.Exists(path)) //should it overwrite ?
                {
                    LogHelper.Info(typeof(EmbeddedResourceService), $"Failed to extract resource '{embeddedResourceItem.ResourceNamespace}' to '{path}', as file already exists");
                }
                else
                {
                    var resourceStream = this.GetResourceStream(embeddedResourceItem);

                    if (resourceStream != null)
                    {
                        new FileInfo(path).Directory.Create();

                        using (var fileStream = File.Create(path))
                        {
                            resourceStream.Seek(0, SeekOrigin.Begin);
                            resourceStream.CopyTo(fileStream);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="embeddedResourceItem"></param>
        /// <returns></returns>
        internal Stream GetResourceStream(EmbeddedResourceItem embeddedResourceItem)
        {

            var a = this.GetAllEmbeddedResourceItems();
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

        /// <summary>
        /// returns true if the current request is logged in as a back office user
        /// https://our.umbraco.com/forum/umbraco-7/using-umbraco-7/72798-how-to-check-if-an-umbraco-user-is-logged-in-on-a-frontend-request
        /// </summary>
        /// <returns></returns>
        internal virtual bool IsBackOfficeUser()
        {
            if (this._httpContext != null)
            {
                var ticket = this._httpContext.GetUmbracoAuthTicket();

                return this._httpContext.AuthenticateCurrentRequest(ticket, true);
            }

            return false;
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
                        x.GetCustomAttributes<EmbeddedResourceExtractAttribute>().Any())
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