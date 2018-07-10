using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.EmbeddedResource.Services;
using System.IO;

namespace Our.Umbraco.EmbeddedResource.Tests.UnitTests
{
    [TestClass]
    [TestCategory("Unit")]
    public class ExtractionUnitTests
    {
        private EmbeddedResourceService _embeddedResourceService;

        /// <summary>
        /// 
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            Helper.WipeTempFolder();

            this._embeddedResourceService = Helper.GetMockEmbeddedResourceService().Object;
        }

        [TestMethod]
        public void Extract_Html()
        {
            var resourceItem = Helper.GetEmbeddedResourceItem(Constants.TestResourceType.Html, false, true);

            var path = Helper.MapPath(resourceItem.ResourceUrl);

            Assert.IsNotNull(path);
            Assert.IsFalse(File.Exists(path));

            this._embeddedResourceService.ExtractToFileSystem(resourceItem);

            Assert.IsTrue(File.Exists(path));
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Extract_Jpg()
        {
            //var resourceItem = Helper.GetEmbeddedResourceItem()
        }

        //private void Extract()
        //{
        //    Assert.Fail();
        //}

    }
}
