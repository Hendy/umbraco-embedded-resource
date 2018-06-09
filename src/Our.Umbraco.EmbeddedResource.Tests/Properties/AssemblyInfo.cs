using Our.Umbraco.EmbeddedResource;
using Our.Umbraco.EmbeddedResource.Tests;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Our.Umbraco.EmbeddedResource.Tests")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Our.Umbraco.EmbeddedResource.Tests")]
[assembly: AssemblyCopyright("Copyright ©  2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: Guid("6ea5a054-b627-4512-b6ed-a3f1bb6141d8")]

// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// Register each of the test embedded resource files
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.html", Constants.HTML_EMBEDDED_RESOURCE_URL)]
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.jpg", Constants.JPG_EMBEDDED_RESOURCE_URL)]
//[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.png", Constants.PNG_RESOURCE_URL)] // commented out so can test without tide prefix
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.png", "/App_Plugins/EmbeddedResourceTests/EmbeddedResource.png")] // to test it registers without the tide prefix

// Attempt to register duplicates
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.jpg", Constants.JPG_EMBEDDED_RESOURCE_URL)]
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.jpg", Constants.JPG_EMBEDDED_RESOURCE_URL)]

// Attempt to register an invalid resource with a valid url
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.Resources.Missing.html", "/App_Plugins/EmbeddedResourceTests/Missing.html")]

// Attempt to register a valid resource with an invalid url
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.html", "http://mysite.com/App_Plugins/EmbeddedResourceTests/ExampleResource.html")]
