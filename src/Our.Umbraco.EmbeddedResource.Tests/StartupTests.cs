using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.EmbeddedResource;
using Our.Umbraco.EmbeddedResource.Events;
using Our.Umbraco.EmbeddedResource.Services;
using Our.Umbraco.EmbeddedResource.Tests;
using System.IO;
using System.Linq;

// Valid registrations ----------------------------------------

[assembly: EmbeddedResource(Constants.Resources.Html.NAMESPACE, Constants.Resources.Html.URL)]
[assembly: EmbeddedResource(Constants.Resources.Jpg.NAMESPACE, Constants.Resources.Jpg.URL)]
//[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.png", Constants.Resources.Png.URL)] // commented out so can test without tide prefix
[assembly: EmbeddedResource(Constants.Resources.Png.NAMESPACE, "/App_Plugins/EmbeddedResourceTests/EmbeddedResource.png")] // not using Constants.Resources.Png.URL, so as to test registration without the tilde prefix
[assembly: EmbeddedResource(Constants.Resources.Txt.NAMESPACE, Constants.Resources.Txt.URL)]

// Register a known resource on another url, and set to protected
[assembly: EmbeddedResourceProtected(Constants.Resources.Txt.NAMESPACE, Constants.Resources.Protected.URL)]

// Register a known resource to be extracted onto file-system
[assembly: EmbeddedResourceExtract(Constants.Resources.Html.NAMESPACE, Constants.Resources.Html.URL)]

// Invalid registrations ----------------------------------------

// Attempt to register duplicates - ignored as attribute definitions are identical
[assembly: EmbeddedResource(Constants.Resources.Jpg.NAMESPACE, Constants.Resources.Jpg.URL)]
[assembly: EmbeddedResource(Constants.Resources.Jpg.NAMESPACE, Constants.Resources.Jpg.URL)]

// Attempt to register an invalid resource with a valid url
[assembly: EmbeddedResource(Constants.Resources.Unknown.NAMESPACE, Constants.Resources.Unknown.URL)]

// Attempt to register a valid resource with an invalid url
[assembly: EmbeddedResource(Constants.Resources.Html.NAMESPACE, "http://mysite.com/App_Plugins/EmbeddedResourceTests/ExampleResource.html")]

// Attempt to register an invalid resource with an invalid url
[assembly: EmbeddedResource(Constants.Resources.Unknown.NAMESPACE, "http://mysite.com/App_Plugins/EmbeddedResourceTests/ExampleResource.html")]


namespace Our.Umbraco.EmbeddedResource.Tests
{
    /// <summary>
    /// Integration tests, where each calls the startup event to initialize the assembly attribute registrations (see above) and then checks for an expected final state
    /// </summary>
    [TestClass]
    public class StartupTests
    {
        private EmbeddedResourceService _embeddedResourceService;

        /// <summary>
        /// Wipe the temp folder then execute the startup before each test
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
            Assert.IsTrue(File.Exists(Helper.MapPath(Constants.Resources.Html.URL)));
        }
    }
}
