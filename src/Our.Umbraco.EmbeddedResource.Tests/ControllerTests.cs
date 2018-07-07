using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Our.Umbraco.EmbeddedResource.Controllers;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web;
using UmbracoWebSecurity = Umbraco.Web.Security.WebSecurity;

namespace Our.Umbraco.EmbeddedResource.Tests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void GetEmbeddedResource_Html()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.HTML_RESOURCE_URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
            Assert.AreEqual("text/html", ((FileStreamResult)embeddedResource).ContentType);
        }

        [TestMethod]
        public void GetEmbeddedResource_Jpg()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.JPG_RESOURCE_URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
            Assert.AreEqual("image/jpeg", ((FileStreamResult)embeddedResource).ContentType);
        }

        [TestMethod]
        public void GetEmbeddedResource_Png()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.PNG_RESOURCE_URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
            Assert.AreEqual("image/png", ((FileStreamResult)embeddedResource).ContentType);
        }

        [TestMethod]
        public void GetEmbeddedResource_Txt()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.TXT_RESOURCE_URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
            Assert.AreEqual("text/plain", ((FileStreamResult)embeddedResource).ContentType);
        }

        [TestMethod]
        public void GetEmbeddedResource_Protected_NotLoggedIn()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.PROTECTED_RESOURCE_URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(HttpNotFoundResult));
        }

        //[TestMethod]
        //public void GetEmbeddedResource_Protected_LoggedIn()
        //{
        //    var controller = new EmbeddedResourceController();

        //    var embeddedResource = controller.GetEmbeddedResource(Constants.PROTECTED_RESOURCE_URL);

        //    Assert.IsNotNull(embeddedResource);
        //    Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
        //    Assert.AreEqual("text/plain", ((FileStreamResult)embeddedResource).ContentType);
        //}

        /// <summary>
        /// valid url request, but no associated embedded resource
        /// </summary>
        [TestMethod]
        public void GetEmbeddedResource_Unknown()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.UNKNOWN_RESOURCE_URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(HttpNotFoundResult));
        }
    }
}
