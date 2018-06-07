using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Our.Umbraco.EmbeddedResource.Tests
{
    /// <summary>
    /// see: Our.Umbraco.EmbeddedResource.Properties.AssemblyInfo.cs for the assembly attributes that define how the test resrouces are registered.
    /// </summary>
    [TestClass]
    public class ServiceTests
    {
        /// <summary>
        /// Expecting to find an 3 registered resource items
        /// </summary>
        [TestMethod]
        public void GetEmeddedResourceItemsCount()
        {
            Assert.IsTrue(EmbeddedResourceService.GetEmbeddedResourceItems().Length == 3);
        }

        [TestMethod]
        public void ExampleResourceHtmlExists()
        {
            Assert.IsTrue(EmbeddedResourceService.ResourceExists("/App_Plugins/EmbeddedResourceTests/ExampleResource.html"));
        }

        [TestMethod]
        public void ExampleResourceJpgExists()
        {
            Assert.IsTrue(EmbeddedResourceService.ResourceExists("/App_Plugins/EmbeddedResourceTests/ExampleResource.jpg"));
        }

        [TestMethod]
        public void ExampleResourcePngExists()
        {
            Assert.IsTrue(EmbeddedResourceService.ResourceExists("~/App_Plugins/EmbeddedResourceTests/ExampleResource.png"));
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
    }
}
