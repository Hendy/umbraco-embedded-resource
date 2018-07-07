using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.EmbeddedResource.Services;
using System.IO;

namespace Our.Umbraco.EmbeddedResource.Tests
{
    /// <summary>
    /// see: Our.Umbraco.EmbeddedResource.Properties.AssemblyInfo.cs for the assembly attributes that define how the test resrouces are registered.
    /// </summary>
    [TestClass]
    public class ServiceTests
    {

        #region ResourceExists

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Html()
        {
            Assert.IsTrue(EmbeddedResourceService.ServedResourceExists(Constants.HTML_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Jpg()
        {
            Assert.IsTrue(EmbeddedResourceService.ServedResourceExists(Constants.JPG_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Png()
        {
            Assert.IsTrue(EmbeddedResourceService.ServedResourceExists(Constants.PNG_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Txt()
        {
            Assert.IsTrue(EmbeddedResourceService.ServedResourceExists(Constants.TXT_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Protected()
        {
            Assert.IsTrue(EmbeddedResourceService.ServedResourceExists(Constants.PROTECTED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Unknown()
        {
            Assert.IsFalse(EmbeddedResourceService.ServedResourceExists(Constants.UNKNOWN_RESOURCE_URL));
        }

        #endregion

        #region GetResourceStream

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Html()
        {
            var html = EmbeddedResourceService.GetServedResourceStream(Constants.HTML_RESOURCE_URL);

            Assert.IsNotNull(html);
            Assert.IsInstanceOfType(html, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Jpg()
        {
            var jpg = EmbeddedResourceService.GetServedResourceStream(Constants.JPG_RESOURCE_URL);

            Assert.IsNotNull(jpg);
            Assert.IsInstanceOfType(jpg, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Png()
        {
            var png = EmbeddedResourceService.GetServedResourceStream(Constants.PNG_RESOURCE_URL);

            Assert.IsNotNull(png);
            Assert.IsInstanceOfType(png, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Txt()
        {
            var txt = EmbeddedResourceService.GetServedResourceStream(Constants.TXT_RESOURCE_URL);

            Assert.IsNotNull(txt);
            Assert.IsInstanceOfType(txt, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Protected()
        {
            var txt = EmbeddedResourceService.GetServedResourceStream(Constants.PROTECTED_RESOURCE_URL);

            Assert.IsNotNull(txt);
            Assert.IsInstanceOfType(txt, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Unknown()
        {
            Assert.IsNull(EmbeddedResourceService.GetServedResourceStream(Constants.UNKNOWN_RESOURCE_URL));
        }

        #endregion
    }
}
