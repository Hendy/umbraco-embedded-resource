using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            new PrivateObject(new EmbeddedResourceStartup()).Invoke("Startup");
        }

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
        public void Routing_Unknown()
        {
            var httpContextMock = new Mock<HttpContextBase>();

            httpContextMock.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath).Returns(Constants.UNKNOWN_EMBEDDED_RESOURCE_URL);

            var routeData = RouteTable.Routes.GetRouteData(httpContextMock.Object);

            Assert.IsNull(routeData);
        }
    }
}
