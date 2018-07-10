using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.EmbeddedResource.Services;
using System.IO;

namespace Our.Umbraco.EmbeddedResource.Tests.IntegrationTests
{
    /// <summary>
    /// All tests use the assembly attributes in Properties.AssemblyInfo.cs as their data-source (emulating consumer api)
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
        public void ResourceExists_Html()
        {
            Assert.IsTrue(this._embeddedResourceService.ServedResourceExists(Constants.TestResources.Html.URL));
        }

        [TestMethod]
        public void ResourceExists_Jpg()
        {
            Assert.IsTrue(this._embeddedResourceService.ServedResourceExists(Constants.TestResources.Jpg.URL));
        }

        [TestMethod]
        public void ResourceExists_Png()
        {
            Assert.IsTrue(this._embeddedResourceService.ServedResourceExists(Constants.TestResources.Png.URL));
        }

        [TestMethod]
        public void ResourceExists_Txt()
        {
            Assert.IsTrue(this._embeddedResourceService.ServedResourceExists(Constants.TestResources.Txt.URL));
        }

        [TestMethod]
        public void ResourceExists_Protected()
        {
            Assert.IsTrue(this._embeddedResourceService.ServedResourceExists(Constants.TestResources.Protected.URL));
        }

        [TestMethod]
        public void ResourceExists_Unknown()
        {
            Assert.IsFalse(this._embeddedResourceService.ServedResourceExists(Constants.TestResources.Unknown.URL));
        }

        #endregion

        #region GetResourceStream

        [TestMethod]
        public void GetResourceStream_Html()
        {
            var html = this._embeddedResourceService.GetServedResourceStream(Constants.TestResources.Html.URL);

            Assert.IsNotNull(html);
            Assert.IsInstanceOfType(html, typeof(Stream));
        }

        [TestMethod]
        public void GetResourceStream_Jpg()
        {
            var jpg = this._embeddedResourceService.GetServedResourceStream(Constants.TestResources.Jpg.URL);

            Assert.IsNotNull(jpg);
            Assert.IsInstanceOfType(jpg, typeof(Stream));
        }

        [TestMethod]
        public void GetResourceStream_Png()
        {
            var png = this._embeddedResourceService.GetServedResourceStream(Constants.TestResources.Png.URL);

            Assert.IsNotNull(png);
            Assert.IsInstanceOfType(png, typeof(Stream));
        }

        [TestMethod]
        public void GetResourceStream_Txt()
        {
            var txt = this._embeddedResourceService.GetServedResourceStream(Constants.TestResources.Txt.URL);

            Assert.IsNotNull(txt);
            Assert.IsInstanceOfType(txt, typeof(Stream));
        }

        [TestMethod]
        public void GetResourceStream_Protected()
        {
            var txt = this._embeddedResourceService.GetServedResourceStream(Constants.TestResources.Protected.URL);

            Assert.IsNotNull(txt);
            Assert.IsInstanceOfType(txt, typeof(Stream));
        }

        [TestMethod]
        public void GetResourceStream_Unknown()
        {
            Assert.IsNull(this._embeddedResourceService.GetServedResourceStream(Constants.TestResources.Unknown.URL));
        }

        #endregion
    }
}
