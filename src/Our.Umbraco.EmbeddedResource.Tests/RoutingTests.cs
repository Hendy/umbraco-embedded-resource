using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.EmbeddedResource.Events;
using Our.Umbraco.EmbeddedResource.Services;
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
            var mockContext = Helper.GetMockHttpContext();

            var service = new EmbeddedResourceService(mockContext.Object);

            service.RegisterResources();
        }

        [TestMethod]
        public void Routing_Html()
        {           
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.Resources.Html.URL).Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.Resources.Html.URL, routeData.Values["url"]);
        }

        [TestMethod]
        public void Routing_Jpg()
        {
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.Resources.Jpg.URL).Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.Resources.Jpg.URL, routeData.Values["url"]);
        }

        [TestMethod]
        public void Routing_Png()
        {
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.Resources.Png.URL).Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.Resources.Png.URL, routeData.Values["url"]);
        }

        [TestMethod]
        public void Routing_Txt()
        {
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.Resources.Txt.URL).Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.Resources.Txt.URL, routeData.Values["url"]);
        }

        [TestMethod]
        public void Routing_Protected()
        {
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.Resources.Protected.URL).Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.Resources.Protected.URL, routeData.Values["url"]);
        }

        [TestMethod]
        public void Routing_Unknown()
        {
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.Resources.Unknown.URL).Object);

            Assert.IsNull(routeData);
        }
    }
}
