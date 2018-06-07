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

// Register each of the test embedded resource
[assembly: EmbeddedResource(Constants.EXAMPLE_RESOURCE_HTML_NAMESPACE, Constants.EXAMPLE_RESOURCE_HTML_URL)]
[assembly: EmbeddedResource(Constants.EXAMPLE_RESOURCE_JPG_NAMESPACE, Constants.EXAMPLE_RESOURCE_JPG_URL)]
[assembly: EmbeddedResource(Constants.EXAMPLE_RESOURCE_PNG_NAMESPACE, Constants.EXAMPLE_RESOURCE_PNG_URL)]