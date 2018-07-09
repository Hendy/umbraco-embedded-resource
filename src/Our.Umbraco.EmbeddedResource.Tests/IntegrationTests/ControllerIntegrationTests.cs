using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.EmbeddedResource.Controllers;
using System.Web.Mvc;

namespace Our.Umbraco.EmbeddedResource.Tests.IntegrationTests
{
    [TestClass]
    [TestCategory("Integration")]
    public class ControllerIntegrationTests
    {
        [TestMethod]
        public void GetEmbeddedResource_Html()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.Resources.Html.URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
            Assert.AreEqual("text/html", ((FileStreamResult)embeddedResource).ContentType);
        }

        [TestMethod]
        public void GetEmbeddedResource_Jpg()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.Resources.Jpg.URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
            Assert.AreEqual("image/jpeg", ((FileStreamResult)embeddedResource).ContentType);
        }

        [TestMethod]
        public void GetEmbeddedResource_Png()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.Resources.Png.URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
            Assert.AreEqual("image/png", ((FileStreamResult)embeddedResource).ContentType);
        }

        [TestMethod]
        public void GetEmbeddedResource_Txt()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.Resources.Txt.URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
            Assert.AreEqual("text/plain", ((FileStreamResult)embeddedResource).ContentType);
        }

        /// <summary>
        /// Attempt to get a protected resource as an anonymous user
        /// </summary>
        [TestMethod]
        public void GetEmbeddedResource_Protected_NotLoggedIn()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.Resources.Protected.URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(HttpNotFoundResult));
        }

        /// <summary>
        /// Get a protected resource as a logged in user
        /// </summary>
        [TestMethod]
        public void GetEmbeddedResource_Protected_LoggedIn()
        {
            var mockService = Helper.GetMockEmbeddedResourceService();

            mockService.Setup(x => x.IsBackOfficeUser()).Returns(true);
                
            var controller = new EmbeddedResourceController(mockService.Object);

            var embeddedResource = controller.GetEmbeddedResource(Constants.Resources.Protected.URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
        }

        /// <summary>
        /// valid url request, but no associated embedded resource
        /// </summary>
        [TestMethod]
        public void GetEmbeddedResource_Unknown()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.Resources.Unknown.URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(HttpNotFoundResult));
        }
    }
}
