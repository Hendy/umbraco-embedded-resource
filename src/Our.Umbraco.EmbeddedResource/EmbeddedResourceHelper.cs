using System.IO;
using System.Linq;
using System.Web;
using Umbraco.Core;

namespace Our.Umbraco.EmbeddedResource
{
    internal static class EmbeddedResourceHelper
    {
        /// <summary>
        /// Returns true if the supplied url maps to an embedded resource
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        internal static bool ResourceExists(string url)
        {
            return false;
            //return typeof(EmbeddedResourceController)
            //        .Assembly
            //        .GetManifestResourceNames()
            //        .Any(x => x.InvariantEquals(resourceName));
        }

        internal static Stream GetResource(string url)
        {
            //var assembly = typeof(EmbeddedResourceController).Assembly;

            //var manifestResourceName = assembly
            //                            .GetManifestResourceNames()
            //                            .FirstOrDefault(x => x.InvariantEquals(resourceName));

            //if (manifestResourceName != null)
            //{
            //    return assembly.GetManifestResourceStream(manifestResourceName);
            //}

            return null;
        }

        //private static string GetResourceNameFromPath(string path)
        //{
        //    string resourceName = null;

        //    if (HttpContext.Current != null) // for unit testing
        //        if (!VirtualPathUtility.IsAppRelative(path))
        //        {
        //            path = VirtualPathUtility.ToAppRelative(path);
        //        }

        //    if (path != null && path.StartsWith(EmbeddedResourceConstants.ROOT_URL))
        //    {
        //        resourceName = EmbeddedResourceConstants.RESOURCE_PREFIX + path.TrimStart(EmbeddedResourceConstants.ROOT_URL).Replace("/", ".").TrimEnd(EmbeddedResourceConstants.FILE_EXTENSION);
        //    }

        //    return resourceName;
        //}


        ///// <summary>
        ///// Determine if a resource exists for the given resource name
        ///// </summary>
        ///// <param name="resource">expecting a namespaced string to the resource</param>
        ///// <returns>true if the resource exists, otherwise false</returns>
        //internal static bool ResourceExists(string resourceName)
        //{
        //    return typeof(EmbeddedResourceController)
        //            .Assembly
        //            .GetManifestResourceNames()
        //            .Any(x => x.InvariantEquals(resourceName));
        //}

        ///// <summary>
        ///// Gets the stream for the given resource name
        ///// </summary>
        ///// <param name="resource">exepted namespaced resource</param>
        ///// <returns>null or the resource stream</returns>
        //internal static Stream GetResource(string resourceName)
        //{
        //    var assembly = typeof(EmbeddedResourceController).Assembly;

        //    var manifestResourceName = assembly
        //                                .GetManifestResourceNames()
        //                                .FirstOrDefault(x => x.InvariantEquals(resourceName));

        //    if (manifestResourceName != null)
        //    {
        //        return assembly.GetManifestResourceStream(manifestResourceName);
        //    }

        //    return null;
        //}

        ///// <summary>
        ///// Convert a url for an embedded resource, to a namespaced string for an embedded resource
        ///// </summary>
        ///// <param name="path">string url to embedded resource</param>
        ///// <returns>null, or a resource namespaced string (the resource may not actually exist)</returns>
        //internal static string GetResourceNameFromPath(string path)
        //{
        //    string resourceName = null;

        //    if (HttpContext.Current != null) // for unit testing
        //        if (!VirtualPathUtility.IsAppRelative(path))
        //        {
        //            path = VirtualPathUtility.ToAppRelative(path);
        //        }

        //    if (path != null && path.StartsWith(EmbeddedResourceConstants.ROOT_URL))
        //    {
        //        resourceName = EmbeddedResourceConstants.RESOURCE_PREFIX + path.TrimStart(EmbeddedResourceConstants.ROOT_URL).Replace("/", ".").TrimEnd(EmbeddedResourceConstants.FILE_EXTENSION);
        //    }

        //    return resourceName;
        //}
    }
}
