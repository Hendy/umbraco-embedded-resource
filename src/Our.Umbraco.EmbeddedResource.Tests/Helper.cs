using Moq;
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
