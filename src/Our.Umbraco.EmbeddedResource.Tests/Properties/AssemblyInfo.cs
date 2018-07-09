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

[assembly: AssemblyVersion("0.3.0.0")]
[assembly: AssemblyFileVersion("0.3.0.0")]

// Valid registrations ----------------------------------------

[assembly: EmbeddedResource(Constants.Resources.Html.NAMESPACE, Constants.Resources.Html.URL)]
[assembly: EmbeddedResource(Constants.Resources.Jpg.NAMESPACE, Constants.Resources.Jpg.URL)]
//[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.png", Constants.Resources.Png.URL)] // commented out so can test without tide prefix
[assembly: EmbeddedResource(Constants.Resources.Png.NAMESPACE, "/App_Plugins/EmbeddedResourceTests/EmbeddedResource.png")] // not using Constants.Resources.Png.URL, so as to test registration without the tilde prefix
[assembly: EmbeddedResource(Constants.Resources.Txt.NAMESPACE, Constants.Resources.Txt.URL)]

// Register a known resource on another url, and set to protected
[assembly: EmbeddedResourceProtected(Constants.Resources.Txt.NAMESPACE, Constants.Resources.Protected.URL)]

// Register a known resource to be extracted onto file-system
[assembly: EmbeddedResourceExtract(Constants.Resources.Html.NAMESPACE, Constants.Resources.Html.URL)]

// Invalid registrations ----------------------------------------

// Attempt to register duplicates - ignored as attribute definitions are identical
[assembly: EmbeddedResource(Constants.Resources.Jpg.NAMESPACE, Constants.Resources.Jpg.URL)]
[assembly: EmbeddedResource(Constants.Resources.Jpg.NAMESPACE, Constants.Resources.Jpg.URL)]

// Attempt to register an invalid resource with a valid url
[assembly: EmbeddedResource(Constants.Resources.Unknown.NAMESPACE, Constants.Resources.Unknown.URL)]

// Attempt to register a valid resource with an invalid url
[assembly: EmbeddedResource(Constants.Resources.Html.NAMESPACE, "http://mysite.com/App_Plugins/EmbeddedResourceTests/ExampleResource.html")]

// Attempt to register an invalid resource with an invalid url
[assembly: EmbeddedResource(Constants.Resources.Unknown.NAMESPACE, "http://mysite.com/App_Plugins/EmbeddedResourceTests/ExampleResource.html")]

