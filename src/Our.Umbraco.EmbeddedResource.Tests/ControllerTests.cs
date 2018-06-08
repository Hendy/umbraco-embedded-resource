using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace Our.Umbraco.EmbeddedResource.Tests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        [TestCategory("Controller_GetEmbeddedResource")]
        public void GetEmbeddedResource_Html()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.HTML_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
            Assert.AreEqual("text/html", ((FileStreamResult)embeddedResource).ContentType);
        }

        [TestMethod]
        [TestCategory("Controller_GetEmbeddedResource")]
        public void GetEmbeddedResource_Jpg()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.JPG_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
            Assert.AreEqual("image/jpeg", ((FileStreamResult)embeddedResource).ContentType);
        }

        [TestMethod]
        [TestCategory("Controller_GetEmbeddedResource")]
        public void GetEmbeddedResource_Png()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.PNG_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
            Assert.AreEqual("image/png", ((FileStreamResult)embeddedResource).ContentType);
        }

        /// <summary>
        /// valid url request, but no associated embedded resource
        /// </summary>
        [TestMethod]
        [TestCategory("Controller_GetEmbeddedResource")]
        public void GetEmbeddedResource_Unknown()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.UNKNOWN_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(HttpNotFoundResult));
        }
    }
}
