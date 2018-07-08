using Moq;
using Our.Umbraco.EmbeddedResource.Models;
using Our.Umbraco.EmbeddedResource.Services;
using System;
using System.IO;
using System.Web;

namespace Our.Umbraco.EmbeddedResource.Tests
{
    internal static class Helper
    {
        /// <summary>
        /// Helper to return a mock httpContext
        /// </summary>
        /// <param name="url">The app relative url for this request</param>
        /// <returns></returns>
        internal static Mock<HttpContextBase> GetMockHttpContext(string url = "~/")
        {
            var httpContextMock = new Mock<HttpContextBase>();

            httpContextMock
                .Setup(x => x.Request.AppRelativeCurrentExecutionFilePath)
                .Returns(url);

            httpContextMock
              .Setup(x => x.Server.MapPath(It.IsAny<string>()))
              .Returns((string x) => Helper.MapPath(x));

            return httpContextMock;
        }

        /// <summary>
        /// Gets a mock of the service using the default root path '~/' as context
        /// </summary>
        /// <returns></returns>
        internal static Mock<EmbeddedResourceService> GetMockEmbeddedResourceService(EmbeddedResourceItem[] embeddedResourceItems = null)
        {
            return Helper.GetMockEmbeddedResourceService(Helper.GetMockHttpContext().Object, embeddedResourceItems);
        }

        /// <summary>
        /// Gets a mock of the service using the supplied context
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="embeddedResourceItems"></param>
        /// <returns></returns>
        internal static Mock<EmbeddedResourceService> GetMockEmbeddedResourceService(HttpContextBase httpContext, EmbeddedResourceItem[] embeddedResourceItems = null)
        {
            var embeddedResourceService = new Mock<EmbeddedResourceService>(httpContext);

            if (embeddedResourceItems != null)
            {
                embeddedResourceService
                    .Setup(x => x.GetAllEmbeddedResourceItems())
                    .Returns(embeddedResourceItems);
            }

            return embeddedResourceService;
        }

        internal static void WipeTempFolder()
        {
            Directory.Delete(Helper.GetTempFolder(), recursive: true);
        }

        /// <summary>
        /// Replacement method for HttpContext.Server.MapPath (so we can use a local temp directory without requiring a web server)
        /// </summary>
        /// <param name="url"></param>
        internal static string MapPath(string url)
        {
            return url
                    .Replace("~/", Helper.GetTempFolder())
                    .Replace("/", "\\");
        }

        /// <summary>
        /// Gets a temp folder ensuring it exists
        /// </summary>
        /// <returns>Returns the string path to the temp folder</returns>
        private static string GetTempFolder()
        {
            var path = Path.GetTempPath() + "Our.Umbraco.EmbeddedResource\\";
            
            new FileInfo(path).Directory.Create(); // ensure folder exists

            return path;
        }
    }
}
