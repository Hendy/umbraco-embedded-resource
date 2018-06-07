﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        /// Expecting to find an 3 registered resource items
        /// </summary>
        [TestMethod]
        public void GetEmeddedResourceItemsCount()
        {
            Assert.IsTrue(EmbeddedResourceService.GetEmbeddedResourceItems().Length == 3);
        }
    }
}
