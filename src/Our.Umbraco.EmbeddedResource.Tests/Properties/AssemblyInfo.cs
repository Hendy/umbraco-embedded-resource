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

// The following are registrations for the integration testing

// Valid registrations ----------------------------------------

[assembly: EmbeddedResource(Constants.TestResources.Html.NAMESPACE, Constants.TestResources.Html.URL)]
[assembly: EmbeddedResource(Constants.TestResources.Jpg.NAMESPACE, Constants.TestResources.Jpg.URL)]
//[assembly: EmbeddedResource("Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.png", Constants.Resources.Png.URL)] // commented out so can test without tide prefix
[assembly: EmbeddedResource(Constants.TestResources.Png.NAMESPACE, "/App_Plugins/EmbeddedResourceTests/EmbeddedResource.png")] // not using Constants.Resources.Png.URL, so as to test registration without the tilde prefix
[assembly: EmbeddedResource(Constants.TestResources.Txt.NAMESPACE, Constants.TestResources.Txt.URL)]

// Register a known resource on another url, and set to protected
[assembly: EmbeddedResourceProtected(Constants.TestResources.Txt.NAMESPACE, Constants.TestResources.Protected.URL)]

// Register a known resource to be extracted onto file-system
[assembly: EmbeddedResourceExtract(Constants.TestResources.Html.NAMESPACE, Constants.TestResources.Html.URL)]

// Invalid registrations ----------------------------------------

// Attempt to register duplicates - ignored as attribute definitions are identical
[assembly: EmbeddedResource(Constants.TestResources.Jpg.NAMESPACE, Constants.TestResources.Jpg.URL)]
[assembly: EmbeddedResource(Constants.TestResources.Jpg.NAMESPACE, Constants.TestResources.Jpg.URL)]

// Attempt to register an invalid resource with a valid url
[assembly: EmbeddedResource(Constants.TestResources.Unknown.NAMESPACE, Constants.TestResources.Unknown.URL)]

// Attempt to register a valid resource with an invalid url
[assembly: EmbeddedResource(Constants.TestResources.Html.NAMESPACE, "http://mysite.com/App_Plugins/EmbeddedResourceTests/ExampleResource.html")]

// Attempt to register an invalid resource with an invalid url
[assembly: EmbeddedResource(Constants.TestResources.Unknown.NAMESPACE, "http://mysite.com/App_Plugins/EmbeddedResourceTests/ExampleResource.html")]

