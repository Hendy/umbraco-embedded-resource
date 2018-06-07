using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Our.Umbraco.EmbeddedResource.Tests
{
    /// <summary>
    /// see: Our.Umbraco.EmbeddedResource.Properties.AssemblyInfo.cs for the assembly attributes that define how the test resrouces are configured.
    /// </summary>
    [TestClass]
    public class StreamingTests
    {
        /// <summary>
        /// Call the (private) startup method which an Umbraco startup event would normally do
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            EmbeddedResourceStartup.Instance.Startup();
        }

        [TestMethod]
        public void ExampleResourceHtmlStreams()
        {
            var html = EmbeddedResourceService.GetResourceStream("~/App_Plugins/EmbeddedResourceTests/ExampleResource.html");

            Assert.IsNotNull(html);
            Assert.IsInstanceOfType(html, typeof(Stream));
        }

        [TestMethod]
        public void ExampleResourceJpgStreams()
        {
            var jpg = EmbeddedResourceService.GetResourceStream("~/App_Plugins/EmbeddedResourceTests/ExampleResource.jpg");

            Assert.IsNotNull(jpg);
            Assert.IsInstanceOfType(jpg, typeof(Stream));
        }

        [TestMethod]
        public void ExampleResourcePngStreams()
        {
            var png = EmbeddedResourceService.GetResourceStream("~/App_Plugins/EmbeddedResourceTests/ExampleResource.png");

            Assert.IsNotNull(png);
            Assert.IsInstanceOfType(png, typeof(Stream));
        }

        //[TestCleanup]
        //public void TestCleanup()
        //{
        //}
    }
}
