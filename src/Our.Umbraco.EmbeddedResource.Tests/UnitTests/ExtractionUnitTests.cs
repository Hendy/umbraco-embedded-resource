using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Our.Umbraco.EmbeddedResource.Tests.UnitTests
{
    [TestClass]
    public class ExtractionUnitTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            Helper.WipeTempFolder();
        }

        [TestMethod]
        public void Extract_Html()
        {
            var resourceItem = new Models.EmbeddedResourceItem(
                                            Constants.TEST_ASSEMBLY_FULL_NAME, 
                                            Constants.Resources.Html.NAMESPACE, 
                                            Constants.Resources.Html.URL, 
                                            false, 
                                            true);

            var path = Helper.MapPath(resourceItem.ResourceUrl);

            Assert.IsNotNull(path);
            Assert.IsFalse(File.Exists(path));

            var mockService = Helper.GetMockEmbeddedResourceService().Object;

            mockService.ExtractToFileSystem(resourceItem);

            Assert.IsTrue(File.Exists(path));
        }
    }
}
