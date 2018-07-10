using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.EmbeddedResource.Events;
using Our.Umbraco.EmbeddedResource.Services;
using System.IO;
using System.Linq;

namespace Our.Umbraco.EmbeddedResource.Tests.IntegrationTests
{
    /// <summary>
    /// All tests use the assembly attributes in Properties.AssemblyInfo.cs as their data-source (emulating consumer api)
    /// </summary>
    [TestClass]
    [TestCategory("Integration")]
    public class StartupIntegrationTests
    {
        private EmbeddedResourceService _embeddedResourceService;

        /// <summary>
        /// Wipe the temp folder then execute the startup before each test - this reads in the attributes (above) as per the consumer API would
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this._embeddedResourceService = Helper.GetMockEmbeddedResourceService().Object;

            Helper.WipeTempFolder();

            new PrivateObject(new EmbeddedResourceStartup()).Invoke("Startup", Helper.GetMockHttpContext().Object);
        }

        [TestMethod]
        public void ExpectingSixTotalResources()
        {
            var embeddedResourceItems = this._embeddedResourceService.GetAllEmbeddedResourceItems();

            Assert.IsNotNull(embeddedResourceItems);
            Assert.AreEqual(6, embeddedResourceItems.Count());
        }

        [TestMethod]
        public void ExpectingFiveServedResources()
        {
            var embeddedResourceItems = this._embeddedResourceService.GetAllEmbeddedResourceItems();

            Assert.IsNotNull(embeddedResourceItems);
            Assert.AreEqual(5, embeddedResourceItems.Where(x => !x.ExtractToFileSystem).Count());
        }

        [TestMethod]
        public void ExpectingFourPublicServedResources()
        {
            var embeddedResourceItems = this._embeddedResourceService.GetAllEmbeddedResourceItems();

            Assert.IsNotNull(embeddedResourceItems);
            Assert.AreEqual(4, embeddedResourceItems.Where(x => !x.BackOfficeUserOnly && !x.ExtractToFileSystem).Count());
        }

        [TestMethod]
        public void ExpectingOneProtectedServedResource()
        {
            var embeddedResourceItems = this._embeddedResourceService.GetAllEmbeddedResourceItems();

            Assert.IsNotNull(embeddedResourceItems);
            Assert.AreEqual(1, embeddedResourceItems.Where(x => x.BackOfficeUserOnly).Count());
        }

        [TestMethod]
        public void ExpectingOneExtractionResource()
        {
            var embeddedResourceItems = this._embeddedResourceService.GetAllEmbeddedResourceItems();

            Assert.IsNotNull(embeddedResourceItems);
            Assert.AreEqual(1, embeddedResourceItems.Where(x => x.ExtractToFileSystem).Count());
        }

        [TestMethod]
        public void HtmlResourceExtracted()
        {
            Assert.IsTrue(File.Exists(Helper.MapPath(Constants.TestResources.Html.URL)));
        }
    }
}
