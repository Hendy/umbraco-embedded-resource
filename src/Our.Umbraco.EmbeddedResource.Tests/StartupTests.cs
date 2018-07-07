using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.EmbeddedResource;
using Our.Umbraco.EmbeddedResource.Events;
using Our.Umbraco.EmbeddedResource.Services;
using Our.Umbraco.EmbeddedResource.Tests;
using System.IO;
using System.Linq;

// Valid registrations ----------------------------------------

[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.html", Constants.HTML_RESOURCE_URL)]
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.jpg", Constants.JPG_RESOURCE_URL)]
//[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.png", Constants.PNG_RESOURCE_URL)] // commented out so can test without tide prefix
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.png", "/App_Plugins/EmbeddedResourceTests/EmbeddedResource.png")] // to test it registers without the tide prefix
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.txt", Constants.TXT_RESOURCE_URL)]

// Register a known resource on another url, and set to protected
[assembly: EmbeddedResourceProtected("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.txt", Constants.PROTECTED_RESOURCE_URL)]

// Register a known resource to be extracted onto file-system
[assembly: EmbeddedResourceExtract("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.html", Constants.HTML_RESOURCE_URL)]

// Invalid registrations ----------------------------------------

// Attempt to register duplicates - ignored as attribute definitions are identical
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.jpg", Constants.JPG_RESOURCE_URL)]
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.jpg", Constants.JPG_RESOURCE_URL)]

// Attempt to register an invalid resource with a valid url
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.Resources.Missing.html", "/App_Plugins/EmbeddedResourceTests/Missing.html")]

// Attempt to register a valid resource with an invalid url
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.html", "http://mysite.com/App_Plugins/EmbeddedResourceTests/ExampleResource.html")]

// Attempt to register an invalid resource with an invalid url
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.Resources.Missing.html", "http://mysite.com/App_Plugins/EmbeddedResourceTests/ExampleResource.html")]


namespace Our.Umbraco.EmbeddedResource.Tests
{
    /// <summary>
    /// Calls the startup event once (as Umbraco would do) which will register the assembly attributes (above)
    /// </summary>
    [TestClass]
    public class StartupTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="testContext"></param>
        [AssemblyInitialize] // Execute only once
        public static void Initialize(TestContext testContext)
        {
            Helper.WipeTempFolder();

            new PrivateObject(new EmbeddedResourceStartup()).Invoke("Startup", Helper.GetMockHttpContext().Object);
        }

        [TestMethod]
        public void ExpectingSixTotalResources()
        {
            var embeddedResourceItems = EmbeddedResourceService.GetAllEmbeddedResourceItems();

            Assert.IsNotNull(embeddedResourceItems);
            Assert.AreEqual(6, embeddedResourceItems.Count());
        }

        [TestMethod]
        public void ExpectingFiveServedResources()
        {
            var embeddedResourceItems = EmbeddedResourceService.GetAllEmbeddedResourceItems();

            Assert.IsNotNull(embeddedResourceItems);
            Assert.AreEqual(5, embeddedResourceItems.Where(x => !x.ExtractToFileSystem).Count());
        }

        [TestMethod]
        public void ExpectingFourPublicServedResources()
        {
            var embeddedResourceItems = EmbeddedResourceService.GetAllEmbeddedResourceItems();

            Assert.IsNotNull(embeddedResourceItems);
            Assert.AreEqual(4, embeddedResourceItems.Where(x => !x.BackOfficeUserOnly && !x.ExtractToFileSystem).Count());
        }

        [TestMethod]
        public void ExpectingOneProtectedServedResource()
        {
            var embeddedResourceItems = EmbeddedResourceService.GetAllEmbeddedResourceItems();

            Assert.IsNotNull(embeddedResourceItems);
            Assert.AreEqual(1, embeddedResourceItems.Where(x => x.BackOfficeUserOnly).Count());
        }

        [TestMethod]
        public void ExpectingOneExtractionResource()
        {
            var embeddedResourceItems = EmbeddedResourceService.GetAllEmbeddedResourceItems();

            Assert.IsNotNull(embeddedResourceItems);
            Assert.AreEqual(1, embeddedResourceItems.Where(x => x.ExtractToFileSystem).Count());
        }

        [TestMethod]
        public void HtmlResourceExtracted()
        {
            Assert.IsTrue(File.Exists(Helper.MapPath(Constants.HTML_RESOURCE_URL)));
        }

    }
}
