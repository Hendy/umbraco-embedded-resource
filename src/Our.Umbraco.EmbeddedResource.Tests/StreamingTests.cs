﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Our.Umbraco.EmbeddedResource.Tests
{
    /// <summary>
    /// see: Our.Umbraco.EmbeddedResource.Properties.AssemblyInfo.cs for the assembly attributes that define how the test resrouces are configured.
    /// </summary>
    [TestClass]
    public class StreamingTests
    {
        /// <summary>
        /// Call the (private) startup method (an Umbraco startup event would normally do this)
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            new PrivateObject(new EmbeddedResourceStartup()).Invoke("Startup");
        }

        [TestMethod]
        public void ExampleResourceHtmlStreams()
        {
            var html = EmbeddedResourceService.GetResourceStream("~/AppPlugins/EmbeddedResourceTests/ExampleResource.html");

            Assert.IsNotNull(html);
            Assert.IsInstanceOfType(html, typeof(Stream));
        }

        [TestMethod]
        public void ExampleResourceJpgStreams()
        {
            var jpg = EmbeddedResourceService.GetResourceStream("~/AppPlugins/EmbeddedResourceTests/ExampleResource.jpg");

            Assert.IsNotNull(jpg);
            Assert.IsInstanceOfType(jpg, typeof(Stream));
        }

        [TestMethod]
        public void ExampleResourcePngStreams()
        {
            var png = EmbeddedResourceService.GetResourceStream("~/AppPlugins/EmbeddedResourceTests/ExampleResource.png");

            Assert.IsNotNull(png);
            Assert.IsInstanceOfType(png, typeof(Stream));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            new PrivateObject(new EmbeddedResourceStartup()).Invoke("Shutdown");
        }
    }
}
