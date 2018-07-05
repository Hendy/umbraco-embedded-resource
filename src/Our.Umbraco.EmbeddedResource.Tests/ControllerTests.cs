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

        [TestMethod]
        [TestCategory("Controller_GetEmbeddedResource")]
        public void GetEmbeddedResource_Txt()
        {
            var controller = new EmbeddedResourceController();

            var embeddedResource = controller.GetEmbeddedResource(Constants.TXT_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(embeddedResource);
            Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
            Assert.AreEqual("text/plain", ((FileStreamResult)embeddedResource).ContentType);
        }

        //[TestMethod]
        //[TestCategory("Controller_GetEmbeddedResource")]
        //public void GetEmbeddedResource_Txt_BackOfficeUserOnly_NotLoggedIn()
        //{

        //    var controller = new EmbeddedResourceController();

        //    var embeddedResource = controller.GetEmbeddedResource(Constants.TXT_BACK_OFFICE_USER_ONLY_EMBEDDED_RESOURCE_URL);

        //    Assert.IsNotNull(embeddedResource);
        //    Assert.IsInstanceOfType(embeddedResource, typeof(HttpNotFoundResult));
        //}

        //[TestMethod]
        //[TestCategory("Controller_GetEmbeddedResource")]
        //public void GetEmbeddedResource_Txt_BackOfficeUserOnly_LoggedIn()
        //{
        //    var controller = new EmbeddedResourceController();

        //    var embeddedResource = controller.GetEmbeddedResource(Constants.TXT_BACK_OFFICE_USER_ONLY_EMBEDDED_RESOURCE_URL);

        //    Assert.IsNotNull(embeddedResource);
        //    Assert.IsInstanceOfType(embeddedResource, typeof(FileStreamResult));
        //    Assert.AreEqual("text/plain", ((FileStreamResult)embeddedResource).ContentType);
        //}

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
