using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.EmbeddedResource.Controllers;
using Our.Umbraco.EmbeddedResource.Services;
using System.Web.Mvc;

namespace Our.Umbraco.EmbeddedResource.Tests.UnitTests
{
    [TestClass]
    [TestCategory("Unit")]
    public class ControllerUnitTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {

        }

        /// <summary>
        /// Get a protected resource as a logged in user
        /// </summary>
        [TestMethod]
        public void GetEmbeddedResource_Protected_LoggedIn()
        {
            var mockService = Helper.GetMockEmbeddedResourceService(Constants.TestResources.Protected.URL);

            mockService.Setup(x => x.IsBackOfficeUser()).Returns(true);

           // mockService.Setup(x => x.GetAllEmbeddedResourceItems()).Returns(new[] { Helper.GetEmbeddedResourceItem(Constants.TestResourceType.Protected) });

            var controller = new EmbeddedResourceController(mockService.Object);

            var embeddedResource = controller.GetEmbeddedResource(Constants.TestResources.Protected.URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
        }

        /// <summary>
        /// Attempt to get a protected resource as an anonymous user
        /// </summary>
        [TestMethod]
        public void GetEmbeddedResource_Protected_NotLoggedIn()
        {
            var mockService = Helper.GetMockEmbeddedResourceService();

            mockService.Setup(x => x.IsBackOfficeUser()).Returns(false);

            var controller = new EmbeddedResourceController(mockService.Object);

            var embeddedResource = controller.GetEmbeddedResource(Constants.TestResources.Protected.URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(HttpNotFoundResult));
        }

    }
}
