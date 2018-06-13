# Umbraco Embedded Resource
For use by Umbraco package developers to serve embedded resources.

Using embedded resources within an assembly for a package has a number of advantages:

1) No need to split a package into two NuGet packages; often a class library project will also need to make a reference, so without the resource files being embedded, they would be added unnecessarily into the class library project.

2) With embedded resources, there's nothing to add (other than a NuGet reference) into source control for the end consumer.

3) Resources can be protected such that they are only served to back office authenticated users (so no [leakage as to what packages are installed](https://twitter.com/jschoemaker1984/status/1004231493240213505)).


## Usage
Once the NuGet package has been installed, the embedded resources in your project need to be registered; this is done via assembly attributes (typically placed in /Properties/AssemblyInfo.cs).

The assembly attribute (Our.Umbraco.EmbeddedResource.EmbeddedResourceAttribute) has three parameters:
* The full namespace path to the embedded resource
* The app relative url that the resource should be served on
* A flag to specify whether the resource should be protected (served to back office users only)


## Example

    @using Our.Umbraco.EmbeddedResource

    // register an embedded jpg as if it were on the file system    
    [assembly: EmbeddedResource("MyPackage.Example.jpg", "/AppPlugins/MyPackage/Example.jpg")]
    
    // register an embedded png, served only to back office users    
    [assembly: EmbeddedResource("MyPackage.Example.png", "/AppPlugins/MyPackage/Example.png", true)]
