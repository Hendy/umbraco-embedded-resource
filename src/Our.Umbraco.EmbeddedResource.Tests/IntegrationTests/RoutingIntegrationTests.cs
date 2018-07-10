using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.EmbeddedResource.Services;
using System.Web.Routing;

namespace Our.Umbraco.EmbeddedResource.Tests.IntegrationTests
{
    /// <summary>
    /// All tests use the assembly attributes in Properties.AssemblyInfo.cs as their data-source (emulating consumer api)
    /// </summary>
    [TestClass]
    [TestCategory("Integration")]
    public class RoutingIntegrationTests
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
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.TestResources.Html.URL).Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.TestResources.Html.URL, routeData.Values["url"]);
        }

        [TestMethod]
        public void Routing_Jpg()
        {
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.TestResources.Jpg.URL).Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.TestResources.Jpg.URL, routeData.Values["url"]);
        }

        [TestMethod]
        public void Routing_Png()
        {
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.TestResources.Png.URL).Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.TestResources.Png.URL, routeData.Values["url"]);
        }

        [TestMethod]
        public void Routing_Txt()
        {
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.TestResources.Txt.URL).Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.TestResources.Txt.URL, routeData.Values["url"]);
        }

        [TestMethod]
        public void Routing_Protected()
        {
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.TestResources.Protected.URL).Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("EmbeddedResource", routeData.Values["controller"]);
            Assert.AreEqual("GetEmbeddedResource", routeData.Values["action"]);
            Assert.AreEqual(Constants.TestResources.Protected.URL, routeData.Values["url"]);
        }

        [TestMethod]
        public void Routing_Unknown()
        {
            var routeData = RouteTable.Routes.GetRouteData(Helper.GetMockHttpContext(Constants.TestResources.Unknown.URL).Object);

            Assert.IsNull(routeData);
        }
    }
}
