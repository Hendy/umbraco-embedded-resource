using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Our.Umbraco.EmbeddedResource.Events;
using System.IO;
using System.Web;
using System.Web.Routing;

namespace Our.Umbraco.EmbeddedResource.Tests
{
    [TestClass]
    public class StartupTests
    {
        [AssemblyInitialize]
        public static void Initialize(TestContext testContext)
        {
            var httpContextMock = new Mock<HttpContextBase>();

            httpContextMock
                .Setup(x => x.Server.MapPath(It.IsAny<string>()))
                .Returns((string x) => Helper.MapPath(x));

            new PrivateObject(new EmbeddedResourceStartup()).Invoke("Startup", httpContextMock.Object);
        }

        #region Routing

        [TestMethod]
        [TestCategory("Startup_Routing")]
        public void Routing_Html()
        {
            var httpContextMock = new Mock<HttpContextBase>();

            httpContextMock.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath).Returns(Constants.HTML_EMBEDDED_RESOURCE_URL);

            var routeData = RouteTable.Routes.GetRouteData(httpContextMock.Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.HTML_EMBEDDED_RESOURCE_URL, routeData.Values["url"]);
        }

        [TestMethod]
        [TestCategory("Startup_Routing")]
        public void Routing_Jpg()
        {
            var httpContextMock = new Mock<HttpContextBase>();

            httpContextMock.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath).Returns(Constants.JPG_EMBEDDED_RESOURCE_URL);

            var routeData = RouteTable.Routes.GetRouteData(httpContextMock.Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.JPG_EMBEDDED_RESOURCE_URL, routeData.Values["url"]);
        }

        [TestMethod]
        [TestCategory("Startup_Routing")]
        public void Routing_Png()
        {
            var httpContextMock = new Mock<HttpContextBase>();

            httpContextMock.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath).Returns(Constants.PNG_EMBEDDED_RESOURCE_URL);

            var routeData = RouteTable.Routes.GetRouteData(httpContextMock.Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.PNG_EMBEDDED_RESOURCE_URL, routeData.Values["url"]);
        }

        [TestMethod]
        [TestCategory("Startup_Routing")]
        public void Routing_Txt()
        {
            var httpContextMock = new Mock<HttpContextBase>();

            httpContextMock.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath).Returns(Constants.TXT_EMBEDDED_RESOURCE_URL);

            var routeData = RouteTable.Routes.GetRouteData(httpContextMock.Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.TXT_EMBEDDED_RESOURCE_URL, routeData.Values["url"]);
        }

        [TestMethod]
        [TestCategory("Startup_Routing")]
        public void Routing_Txt_BackOfficeUserOnly()
        {
            var httpContextMock = new Mock<HttpContextBase>();

            httpContextMock.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath).Returns(Constants.TXT_BACK_OFFICE_USER_ONLY_EMBEDDED_RESOURCE_URL);

            var routeData = RouteTable.Routes.GetRouteData(httpContextMock.Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.TXT_BACK_OFFICE_USER_ONLY_EMBEDDED_RESOURCE_URL, routeData.Values["url"]);
        }

        [TestMethod]
        [TestCategory("Startup_Routing")]
        public void Routing_Unknown()
        {
            var httpContextMock = new Mock<HttpContextBase>();

            httpContextMock.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath).Returns(Constants.UNKNOWN_EMBEDDED_RESOURCE_URL);

            var routeData = RouteTable.Routes.GetRouteData(httpContextMock.Object);

            Assert.IsNull(routeData);
        }

        #endregion

        #region Extraction


        //[assembly: EmbeddedResourceExtract("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.html", Constants.HTML_EMBEDDED_RESOURCE_URL)]
        [TestMethod]
        [TestCategory("Startup_Extraction")]
        public void Extraction_Html()
        {
            Assert.IsTrue(File.Exists(Helper.MapPath(Constants.HTML_EMBEDDED_RESOURCE_URL)));
        }

        #endregion
    }
}
