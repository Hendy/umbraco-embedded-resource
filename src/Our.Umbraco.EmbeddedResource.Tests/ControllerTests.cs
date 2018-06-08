using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Mvc;

namespace Our.Umbraco.EmbeddedResource.Tests
{
    [TestClass]
    public class ControllerTests
    {
        /// <summary>
        /// valid url request, but no associated embedded resource
        /// </summary>
        [TestMethod]
        public void UnknownResource()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource("~/App_Plugins/EmbeddedResourceTests/Unknown");

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void HtmlResource()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource("~/App_Plugins/EmbeddedResourceTests/ExampleResource.html");

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
            Assert.AreEqual("text/html", ((FileStreamResult)embeddedResource).ContentType);
        }
    }
}
