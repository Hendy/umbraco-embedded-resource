using Moq;
using Our.Umbraco.EmbeddedResource.Services;
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
        /// Gets a mock of the service that doesn't read in the assembly attributes, but are set for testing purposes
        /// </summary>
        /// <returns></returns>
        internal static Mock<EmbeddedResourceService> GetMockEmbeddedResourceService()
        {
            var embeddedResourceService = new Mock<EmbeddedResourceService>(Helper.GetMockHttpContext().Object);

            return embeddedResourceService;
        }

        internal static void WipeTempFolder()
        {

        }

        /// <summary>
        /// Replacement method for HttpContext.Server.MapPath (so we can use a local temp directory without requiring a web server)
        /// </summary>
        /// <param name="path"></param>
        internal static string MapPath(string path)
        {
            var tempPath = Path.GetTempPath() + "Our.Umbraco.EmbeddedResource\\";

            return path
                    .Replace("~/", tempPath)
                    .Replace("/", "\\");
        }

    }
}
