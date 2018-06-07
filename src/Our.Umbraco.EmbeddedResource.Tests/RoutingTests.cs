using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;

namespace Our.Umbraco.EmbeddedResource.Tests
{
    /// <summary>
    /// see: Our.Umbraco.EmbeddedResource.Properties.AssemblyInfo.cs for the assembly attributes that define how the test resrouces are configured.
    /// </summary>
    [TestClass]
    public class RoutingTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            new PrivateObject(new EmbeddedResourceStartup()).Invoke("Startup");
        }

        [TestMethod]
        public void ExampleResourceHtmlExists()
        {
            Assert.IsTrue(EmbeddedResourceService.ResourceExists("~/App_Plugins/EmbeddedResourceTests/ExampleResource.html"));
        }

        [TestMethod]
        public void ExampleResourceJpgExists()
        {
            Assert.IsTrue(EmbeddedResourceService.ResourceExists("~/App_Plugins/EmbeddedResourceTests/ExampleResource.jpg"));
        }

        [TestMethod]
        public void ExampleResourcePngExists()
        {
            Assert.IsTrue(EmbeddedResourceService.ResourceExists("~/App_Plugins/EmbeddedResourceTests/ExampleResource.png"));
        }

        //[TestCleanup]
        //public void TestCleanup()
        //{            
        //}
    }
}
