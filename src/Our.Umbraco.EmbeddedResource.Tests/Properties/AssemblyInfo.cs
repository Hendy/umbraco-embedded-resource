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
// Note: 
//  The first parameter is always set exactly, as it needs to map to a known resource
//  The second parameter for the url varies (so variants can be tested)
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.Resources.ExampleResource.html", "~/App_Plugins/EmbeddedResourceTests/ExampleResource.html")]
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.Resources.ExampleResource.jpg", "/App_Plugins/EmbeddedResourceTests/ExampleResource.jpg")]
[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.Resources.ExampleResource.png", "App_Plugins/EmbeddedResourceTests/ExampleResource.png")]