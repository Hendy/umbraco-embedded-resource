using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.EmbeddedResource.Services;
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
        public void GetEmbeddedResourceItems_ExpectedCount_BackOfficeUserOnly()
        {
            var embeddedResourceItems = EmbeddedResourceService.GetAllEmbeddedResourceItems();

            Assert.IsNotNull(embeddedResourceItems);
            Assert.AreEqual(1, embeddedResourceItems.Where(x => x.BackOfficeUserOnly).Count());
        }

        #region ResourceExists

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Html()
        {
            Assert.IsTrue(EmbeddedResourceService.ServedResourceExists(Constants.HTML_EMBEDDED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Jpg()
        {
            Assert.IsTrue(EmbeddedResourceService.ServedResourceExists(Constants.JPG_EMBEDDED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Png()
        {
            Assert.IsTrue(EmbeddedResourceService.ServedResourceExists(Constants.PNG_EMBEDDED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Txt()
        {
            Assert.IsTrue(EmbeddedResourceService.ServedResourceExists(Constants.TXT_EMBEDDED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Txt_BackOfficeUserOnly()
        {
            Assert.IsTrue(EmbeddedResourceService.ServedResourceExists(Constants.TXT_BACK_OFFICE_USER_ONLY_EMBEDDED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Unknown()
        {
            Assert.IsFalse(EmbeddedResourceService.ServedResourceExists(Constants.UNKNOWN_EMBEDDED_RESOURCE_URL));
        }

        #endregion

        #region GetResourceStream

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Html()
        {
            var html = EmbeddedResourceService.GetServedResourceStream(Constants.HTML_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(html);
            Assert.IsInstanceOfType(html, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Jpg()
        {
            var jpg = EmbeddedResourceService.GetServedResourceStream(Constants.JPG_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(jpg);
            Assert.IsInstanceOfType(jpg, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Png()
        {
            var png = EmbeddedResourceService.GetServedResourceStream(Constants.PNG_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(png);
            Assert.IsInstanceOfType(png, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Txt()
        {
            var txt = EmbeddedResourceService.GetServedResourceStream(Constants.TXT_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(txt);
            Assert.IsInstanceOfType(txt, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Txt_BackOfficeUserOnly()
        {
            var txt = EmbeddedResourceService.GetServedResourceStream(Constants.TXT_BACK_OFFICE_USER_ONLY_EMBEDDED_RESOURCE_URL);

            Assert.IsNotNull(txt);
            Assert.IsInstanceOfType(txt, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Unknown()
        {
            Assert.IsNull(EmbeddedResourceService.GetServedResourceStream(Constants.UNKNOWN_EMBEDDED_RESOURCE_URL));
        }

        #endregion
    }
}
