using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Our.Umbraco.EmbeddedResource.Tests
{
    [TestClass]
    public class RoutingTests
    {
        /// <summary>
        /// Call the (private) startup method (an Umbraco startup event would normally do this)
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            new PrivateObject(new EmbeddedResourceStartup()).Invoke("Startup");
        }

        [TestMethod]
        public void ExampleResourceJpgExists()
        {
            Assert.IsTrue(EmbeddedResourceHelper.ResourceExists(Constants.EXAMPLE_RESOURCE_JPG_URL));
        }

        [TestMethod]
        public void ExampleResourcePngExists()
        {
            Assert.IsTrue(EmbeddedResourceHelper.ResourceExists(Constants.EXAMPLE_RESOURCE_PNG_URL));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            new PrivateObject(new EmbeddedResourceStartup()).Invoke("Shutdown");
        }
    }
}
