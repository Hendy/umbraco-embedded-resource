using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.EmbeddedResource;

[assembly: EmbeddedResource("EmbeddedResourceTests", "Our.Umbraco.EmbeddedResource.Tests", new string[] { "html", "css", "js" })]

namespace Our.Umbraco.EmbeddedResource.Tests
{
    [TestClass]
    public class StartupTests
    {
        /// <summary>
        /// Call the (private) startup method (an Umbraco startup event would normally do this)
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            new PrivateObject(new EmbeddedResourceStartup()).Invoke("Startup");
        }

        /// <summary>
        /// Test to check that the startup event will reflect and find the assembly attribute (as registered above this class)
        /// </summary>
        [TestMethod]
        public void EnsureStartupReadsAssemblyAttribute()
        {
            Assert.Inconclusive();
        }
    }
}
