using Moq;
using Our.Umbraco.EmbeddedResource.Models;
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
        /// Get a mock of the service using the default root path '~/' as context
        /// </summary>
        /// <returns></returns>
        internal static Mock<EmbeddedResourceService> GetMockEmbeddedResourceService(string url = "~/")
        {
            return Helper.GetMockEmbeddedResourceService(Helper.GetMockHttpContext(url).Object);
        }

        /// <summary>
        /// Get a mock of the service using the supplied context
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        internal static Mock<EmbeddedResourceService> GetMockEmbeddedResourceService(HttpContextBase httpContext)
        {
            return new Mock<EmbeddedResourceService>(httpContext) { CallBase = true }; // the GetAllEmbeddedResourceItems has been marked as virtual
        }

        /// <summary>
        /// Builds a POCO model to represent a single embedded resource registation (would normally be built from parsing a consumer assembly attribute)
        /// </summary>
        /// <param name="embeddedResourceType">specifying the type enables the correct namespace & url parameters to be used</param>
        /// <param name="backOfficeOnly">when true, this resource is only availble to authenticated Umbraco users</param>
        /// <param name="extractToFileSystem">when true, this resource indicates it should be extracted to the file-system</param>
        /// <returns></returns>
        internal static EmbeddedResourceItem GetEmbeddedResourceItem(Constants.TestResourceType embeddedResourceType, bool backOfficeOnly = false, bool extractToFileSystem = false)
        {
            switch (embeddedResourceType)
            {
                case Constants.TestResourceType.Html: return new EmbeddedResourceItem(Constants.TEST_ASSEMBLY_FULL_NAME, Constants.TestResources.Html.NAMESPACE, Constants.TestResources.Html.URL, backOfficeOnly, extractToFileSystem);
                case Constants.TestResourceType.Jpg: return new EmbeddedResourceItem(Constants.TEST_ASSEMBLY_FULL_NAME, Constants.TestResources.Jpg.NAMESPACE, Constants.TestResources.Jpg.URL, backOfficeOnly, extractToFileSystem);
                case Constants.TestResourceType.Png: return new EmbeddedResourceItem(Constants.TEST_ASSEMBLY_FULL_NAME, Constants.TestResources.Png.NAMESPACE, Constants.TestResources.Png.URL, backOfficeOnly, extractToFileSystem);
                case Constants.TestResourceType.Txt: return new EmbeddedResourceItem(Constants.TEST_ASSEMBLY_FULL_NAME, Constants.TestResources.Txt.NAMESPACE, Constants.TestResources.Txt.URL, backOfficeOnly, extractToFileSystem);
                case Constants.TestResourceType.Protected: return new EmbeddedResourceItem(Constants.TEST_ASSEMBLY_FULL_NAME, Constants.TestResources.Protected.NAMESPACE, Constants.TestResources.Protected.URL, backOfficeOnly, extractToFileSystem);
                case Constants.TestResourceType.Unknown: return new EmbeddedResourceItem(Constants.TEST_ASSEMBLY_FULL_NAME, Constants.TestResources.Unknown.NAMESPACE, Constants.TestResources.Unknown.URL, backOfficeOnly, extractToFileSystem);

                default:
                    return null;
            }
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
