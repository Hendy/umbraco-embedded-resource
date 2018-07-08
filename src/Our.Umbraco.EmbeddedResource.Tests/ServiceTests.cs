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
        [TestMethod]
        [TestCategory("Service_ExtractToFileSystem")]
        public void ExtractToFileSystem_Html()
        {
            Helper.WipeTempFolder();

            var path = Helper.MapPath(Constants.HTML_RESOURCE_URL);

            Assert.IsNotNull(path);
            Assert.IsFalse(File.Exists(path));

            // trigger 
            var mockService = Helper.GetMockEmbeddedResourceService();

           


        }


        #region ResourceExists

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Html()
        {
            Assert.IsTrue(Helper.GetMockEmbeddedResourceService().Object.ServedResourceExists(Constants.HTML_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Jpg()
        {
            Assert.IsTrue(Helper.GetMockEmbeddedResourceService().Object.ServedResourceExists(Constants.JPG_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Png()
        {
            Assert.IsTrue(Helper.GetMockEmbeddedResourceService().Object.ServedResourceExists(Constants.PNG_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Txt()
        {
            Assert.IsTrue(Helper.GetMockEmbeddedResourceService().Object.ServedResourceExists(Constants.TXT_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Protected()
        {
            Assert.IsTrue(Helper.GetMockEmbeddedResourceService().Object.ServedResourceExists(Constants.PROTECTED_RESOURCE_URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Unknown()
        {
            Assert.IsFalse(Helper.GetMockEmbeddedResourceService().Object.ServedResourceExists(Constants.UNKNOWN_RESOURCE_URL));
        }

        #endregion

        #region GetResourceStream

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Html()
        {
            var html = Helper.GetMockEmbeddedResourceService().Object.GetServedResourceStream(Constants.HTML_RESOURCE_URL);

            Assert.IsNotNull(html);
            Assert.IsInstanceOfType(html, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Jpg()
        {
            var jpg = Helper.GetMockEmbeddedResourceService().Object.GetServedResourceStream(Constants.JPG_RESOURCE_URL);

            Assert.IsNotNull(jpg);
            Assert.IsInstanceOfType(jpg, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Png()
        {
            var png = Helper.GetMockEmbeddedResourceService().Object.GetServedResourceStream(Constants.PNG_RESOURCE_URL);

            Assert.IsNotNull(png);
            Assert.IsInstanceOfType(png, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Txt()
        {
            var txt = Helper.GetMockEmbeddedResourceService().Object.GetServedResourceStream(Constants.TXT_RESOURCE_URL);

            Assert.IsNotNull(txt);
            Assert.IsInstanceOfType(txt, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Protected()
        {
            var txt = Helper.GetMockEmbeddedResourceService().Object.GetServedResourceStream(Constants.PROTECTED_RESOURCE_URL);

            Assert.IsNotNull(txt);
            Assert.IsInstanceOfType(txt, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Unknown()
        {
            Assert.IsNull(Helper.GetMockEmbeddedResourceService().Object.GetServedResourceStream(Constants.UNKNOWN_RESOURCE_URL));
        }

        #endregion
    }
}
