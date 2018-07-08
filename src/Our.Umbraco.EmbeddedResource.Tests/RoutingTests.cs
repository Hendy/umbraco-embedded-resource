using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.EmbeddedResource.Events;
using System.Web.Routing;

namespace Our.Umbraco.EmbeddedResource.Tests
{
    /// <summary>
    /// Checks all consumer assembly attributes were found and registered correctly
    /// </summary>
    [TestClass]
    public class RoutingTests
    {
        [TestInitialize]
        public void Initialize()
        {
            new PrivateObject(new EmbeddedResourceStartup()).Invoke("Startup", Helper.GetMockHttpContext().Object);
        }

        [TestMethod]
        public void Routing_Html()
        {           
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.HTML_RESOURCE_URL).Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.HTML_RESOURCE_URL, routeData.Values["url"]);
        }

        [TestMethod]
        public void Routing_Jpg()
        {
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.JPG_RESOURCE_URL).Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.JPG_RESOURCE_URL, routeData.Values["url"]);
        }

        [TestMethod]
        public void Routing_Png()
        {
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.PNG_RESOURCE_URL).Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.PNG_RESOURCE_URL, routeData.Values["url"]);
        }

        [TestMethod]
        public void Routing_Txt()
        {
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.TXT_RESOURCE_URL).Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.TXT_RESOURCE_URL, routeData.Values["url"]);
        }

        [TestMethod]
        public void Routing_Protected()
        {
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.PROTECTED_RESOURCE_URL).Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.PROTECTED_RESOURCE_URL, routeData.Values["url"]);
        }

        [TestMethod]
        public void Routing_Unknown()
        {
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.UNKNOWN_RESOURCE_URL).Object);

            Assert.IsNull(routeData);
        }
    }
}
