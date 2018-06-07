using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Routing;

namespace Our.Umbraco.EmbeddedResource.Tests
{
    [TestClass]
    public class StartupTests
    {
        [AssemblyInitialize]
        public static void Initialize(TestContext testContext)
        {
            new PrivateObject(new EmbeddedResourceStartup()).Invoke("Startup");
        }

        //[TestMethod]
        //public void ExampleResourceHtmlRoute()
        //{
        //}

    }
}
