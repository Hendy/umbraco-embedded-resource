using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Our.Umbraco.EmbeddedResource.Tests
{
    /// <summary>
    /// see: Our.Umbraco.EmbeddedResource.Properties.AssemblyInfo.cs for the assembly attributes that define how the test resrouces are registered.
    /// </summary>
    [TestClass]
    public class ServiceTests
    {
        /// <summary>
        /// Expecting to find an item for each of the registered resources
        /// </summary>
        [TestMethod]
        public void GetEmeddedResourceItems()
        {
            var embeddedResourceItems = EmbeddedResourceService.GetEmbeddedResourceItems();

            Assert.IsNotNull(embeddedResourceItems);
            Assert.IsTrue(embeddedResourceItems.Length == 3);
        }

        [TestMethod]
        public void GetAssembliesForEmbeddedResourceItems()
        {
            foreach (var embeddedResourceItem in EmbeddedResourceService.GetEmbeddedResourceItems())
            {
                Assert.IsNotNull(embeddedResourceItem);

                
            }
        }
    }
}
