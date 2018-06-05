using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.EmbeddedResource;

// register each embedded resource explicity
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.ExampleResource.jpg", "~/AppPlugins/EmbeddedResourceTests/ExampleResource.jpg")]
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.ExampleResource.png", "~/AppPlugins/EmbeddedResourceTests/ExampleResource.png")]

// register multiple resources by convention (not required for initial release)
//[assembly: EmbeddedResources("Our.Umbraco.EmbeddedResource.Tests", "~/App_Plugins/EmbeddedResourceTests/")]

namespace Our.Umbraco.EmbeddedResource.Tests
{
    [TestClass]
    public class StartupTests
    {
        /// <summary>
        /// Call the (private) startup method (an Umbraco startup event would normally do this)
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            // the startup process will look for all EmbeddedResource assembly attributes and then register resources
            new PrivateObject(new EmbeddedResourceStartup()).Invoke("Startup");
        }

        [TestMethod]
        public void ExistsExampleResourceJpg()
        {
            Assert.IsTrue(EmbeddedResourceHelper.ResourceExists("~/AppPlugins/EmbeddedResourceTests/ExampleResource.jpg"));
        }

        [TestMethod]
        public void StreamExampleResourceJpg()
        {
            var jpg = EmbeddedResourceHelper.GetResource("~/AppPlugins/EmbeddedResourceTests/ExampleResource.jpg");

            Assert.IsNotNull(jpg);
        }

        [TestMethod]
        public void ExistsExampleResourcePng()
        {
            Assert.IsTrue(EmbeddedResourceHelper.ResourceExists("~/AppPlugins/EmbeddedResourceTests/ExampleResource.png"));
        }

        [TestMethod]
        public void StreamExampleResourcePng()
        {
            var png = EmbeddedResourceHelper.GetResource("~/AppPlugins/EmbeddedResourceTests/ExampleResource.png");

            Assert.IsNotNull(png);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            new PrivateObject(new EmbeddedResourceStartup()).Invoke("Shutdown");
        }
    }
}
