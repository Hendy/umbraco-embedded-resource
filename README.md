# Umbraco Embedded Resource
For use by package developers to serve embedded assets.

Using embedded resources within an assembly for an Umbraco package has a number of advantages:

1) No need to split a package into two NuGet packages; often a class library project will also need to make a reference to the package, and if the resource files are not embedded, then they are added unnecessarily into that project.

2) Without resource files on the file system, there's nothing to add (other than the NuGet reference) into source control for the end consumer.

3) Resources can be protected such that they are only served to back office authenticated users (so no public leakage as to what packages are installed)


## Usage:
Once the NuGet package has been installed, the embedded resources in your project need to be registered and this is done via assembly attributes (typically placed in /Properties/AssemblyInfo.cs).

The assembly attribute (Our.Umbraco.EmbeddedResource.EmbeddedResourceAttribute) has three parameters:
* The full namespace path to the embedded resource
* The app relative url that the resource should be served on
* A flag to specify whether the resource should be protected (ie served to back office users only)

    @using Our.Umbraco.EmbeddedResource

    // register an embedded jpg as if it were on the file system    
    [assembly: EmbeddedResource("MyPackage.Example.jpg", "/AppPlugins/MyPackage/Example.jpg")]
    
    // register an embedded png, served only to back office users    
    [assembly: EmbeddedResource("MyPackage.Example.png", "/AppPlugins/MyPackage/Example.png", true)]
