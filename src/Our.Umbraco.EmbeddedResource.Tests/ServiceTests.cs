using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace Our.Umbraco.EmbeddedResource.Tests
{
    /// <summary>
    /// see: Our.Umbraco.EmbeddedResource.Properties.AssemblyInfo.cs for the assembly attributes that define how the test resrouces are registered.
    /// </summary>
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        [TestCategory("Service_GetEmbeddedResourceItems")]
        public void GetEmbeddedResourceItems_ExpectedCount_NotBackOfficeUserOnly()
        {
            var embeddedResourceItems = EmbeddedResourceService.GetEmbeddedResourceItems();

            Assert.IsNotNull(embeddedResourceItems);
            Assert.IsTrue(embeddedResourceItems.Where(x => !x.BackOfficeUserOnly).Count() == 4);
        }

        [TestMethod]
        [TestCategory("Service_GetEmbeddedResourceItems")]
        public void GetEmbeddedResourceItems_ExpectedCount_BackOfficeUserOnly()
        {
            var embeddedResourceItems = EmbeddedResourceService.GetEmbeddedResourceItems();

            Assert.IsNotNull(embeddedResourceItems);
            Assert.IsTrue(embeddedResourceItems.Where(x => x.BackOfficeUserOnly).Count() == 1);
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Html()
        {
            Assert.IsTrue(EmbeddedResourceService.ResourceExists(Constants.HTML_EMBEDDED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Jpg()
        {
            Assert.IsTrue(EmbeddedResourceService.ResourceExists(Constants.JPG_EMBEDDED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Png()
        {
            Assert.IsTrue(EmbeddedResourceService.ResourceExists(Constants.PNG_EMBEDDED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Txt()
        {
            Assert.IsTrue(EmbeddedResourceService.ResourceExists(Constants.TXT_EMBEDDED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Txt_BackOfficeUserOnly()
        {
            Assert.IsTrue(EmbeddedResourceService.ResourceExists(Constants.TXT_BACK_OFFICE_USER_ONLY_EMBEDDED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Unknown()
        {
            Assert.IsFalse(EmbeddedResourceService.ResourceExists(Constants.UNKNOWN_EMBEDDED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Html()
        {
            var html = EmbeddedResourceService.GetResourceStream(Constants.HTML_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(html);
            Assert.IsInstanceOfType(html, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Jpg()
        {
            var jpg = EmbeddedResourceService.GetResourceStream(Constants.JPG_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(jpg);
            Assert.IsInstanceOfType(jpg, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Png()
        {
            var png = EmbeddedResourceService.GetResourceStream(Constants.PNG_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(png);
            Assert.IsInstanceOfType(png, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Txt()
        {
            var txt = EmbeddedResourceService.GetResourceStream(Constants.TXT_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(txt);
            Assert.IsInstanceOfType(txt, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Txt_BackOfficeUserOnly()
        {
            var txt = EmbeddedResourceService.GetResourceStream(Constants.TXT_BACK_OFFICE_USER_ONLY_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(txt);
            Assert.IsInstanceOfType(txt, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Unknown()
        {
            Assert.IsNull(EmbeddedResourceService.GetResourceStream(Constants.UNKNOWN_EMBEDDED_RESOURCE_URL));
        }
    }
}
