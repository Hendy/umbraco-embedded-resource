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
        public void GetEmbeddedResourceItems()
        {
            var embeddedResourceItems = EmbeddedResourceService.GetEmbeddedResourceItems();

            Assert.IsNotNull(embeddedResourceItems);
            Assert.IsTrue(embeddedResourceItems.Length == 3, "Expected 3 successfully registered embedded resource files");
        }

        [TestMethod]
        [TestCategory("ResourceExists")]
        public void ResourceExists_Html()
        {
            Assert.IsTrue(EmbeddedResourceService.ResourceExists(Constants.HTML_EMBEDDED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("ResourceExists")]
        public void ResourceExists_Jpg()
        {
            Assert.IsTrue(EmbeddedResourceService.ResourceExists(Constants.JPG_EMBEDDED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("ResourceExists")]
        public void ResourceExists_Png()
        {
            Assert.IsTrue(EmbeddedResourceService.ResourceExists(Constants.PNG_EMBEDDED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("ResourceExists")]
        public void ResourceExists_Unknown()
        {
            Assert.IsFalse(EmbeddedResourceService.ResourceExists(Constants.UNKNOWN_EMBEDDED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("GetResourceStream")]
        public void GetResourceStream_Html()
        {
            var html = EmbeddedResourceService.GetResourceStream(Constants.HTML_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(html);
            Assert.IsInstanceOfType(html, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("GetResourceStream")]
        public void GetResourceStream_Jpg()
        {
            var jpg = EmbeddedResourceService.GetResourceStream(Constants.JPG_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(jpg);
            Assert.IsInstanceOfType(jpg, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("GetResourceStream")]
        public void GetResourceStream_Png()
        {
            var png = EmbeddedResourceService.GetResourceStream(Constants.PNG_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(png);
            Assert.IsInstanceOfType(png, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("GetResourceStream")]
        public void GetResourceStream_Unknown()
        {
            Assert.IsNull(EmbeddedResourceService.GetResourceStream(Constants.UNKNOWN_EMBEDDED_RESOURCE_URL));
        }
    }
}
