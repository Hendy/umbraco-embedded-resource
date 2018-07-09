using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.EmbeddedResource.Services;
using System.IO;

namespace Our.Umbraco.EmbeddedResource.Tests.IntegrationTests
{
    /// <summary>
    /// see: Our.Umbraco.EmbeddedResource.Properties.AssemblyInfo.cs for the assembly attributes that define how the test resrouces are registered.
    /// </summary>
    [TestClass]
    [TestCategory("Integration")]
    public class ServiceIntegrationTests
    {
        private EmbeddedResourceService _embeddedResourceService;

        [TestInitialize]
        public void Initialize()
        {
            this._embeddedResourceService = Helper.GetMockEmbeddedResourceService().Object;
            
        }

        #region ResourceExists

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Html()
        {
            Assert.IsTrue(this._embeddedResourceService.ServedResourceExists(Constants.Resources.Html.URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Jpg()
        {
            Assert.IsTrue(this._embeddedResourceService.ServedResourceExists(Constants.Resources.Jpg.URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Png()
        {
            Assert.IsTrue(this._embeddedResourceService.ServedResourceExists(Constants.Resources.Png.URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Txt()
        {
            Assert.IsTrue(this._embeddedResourceService.ServedResourceExists(Constants.Resources.Txt.URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Protected()
        {
            Assert.IsTrue(this._embeddedResourceService.ServedResourceExists(Constants.Resources.Protected.URL));
        }

        [TestMethod]
        [TestCategory("Service_ResourceExists")]
        public void ResourceExists_Unknown()
        {
            Assert.IsFalse(this._embeddedResourceService.ServedResourceExists(Constants.Resources.Unknown.URL));
        }

        #endregion

        #region GetResourceStream

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Html()
        {
            var html = this._embeddedResourceService.GetServedResourceStream(Constants.Resources.Html.URL);

            Assert.IsNotNull(html);
            Assert.IsInstanceOfType(html, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Jpg()
        {
            var jpg = this._embeddedResourceService.GetServedResourceStream(Constants.Resources.Jpg.URL);

            Assert.IsNotNull(jpg);
            Assert.IsInstanceOfType(jpg, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Png()
        {
            var png = this._embeddedResourceService.GetServedResourceStream(Constants.Resources.Png.URL);

            Assert.IsNotNull(png);
            Assert.IsInstanceOfType(png, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Txt()
        {
            var txt = this._embeddedResourceService.GetServedResourceStream(Constants.Resources.Txt.URL);

            Assert.IsNotNull(txt);
            Assert.IsInstanceOfType(txt, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Protected()
        {
            var txt = this._embeddedResourceService.GetServedResourceStream(Constants.Resources.Protected.URL);

            Assert.IsNotNull(txt);
            Assert.IsInstanceOfType(txt, typeof(Stream));
        }

        [TestMethod]
        [TestCategory("Service_GetResourceStream")]
        public void GetResourceStream_Unknown()
        {
            Assert.IsNull(this._embeddedResourceService.GetServedResourceStream(Constants.Resources.Unknown.URL));
        }

        #endregion
    }
}
