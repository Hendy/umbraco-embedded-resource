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
        [TestCategory("Routing")]
        public void UnknownRoute()
        {
            var httpContextMock = new Mock<HttpContextBase>();

            httpContextMock.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Unknown");

            var routeData = RouteTable.Routes.GetRouteData(httpContextMock.Object);

            Assert.IsNull(routeData);
        }

        [TestMethod]
        [TestCategory("Routing")]
        public void HtmlRoute()
        {
            var httpContextMock = new Mock<HttpContextBase>();

            httpContextMock.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath).Returns("~/App_Plugins/EmbeddedResourceTests/ExampleResource.html");

            var routeData = RouteTable.Routes.GetRouteData(httpContextMock.Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual("~/App_Plugins/EmbeddedResourceTests/ExampleResource.html", routeData.Values["url"]);
        }

    }
}
