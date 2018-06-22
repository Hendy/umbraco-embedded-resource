# Umbraco Embedded Resource
For use by Umbraco package developers to serve embedded resources.

[The NuGet package](https://www.nuget.org/packages/Our.Umbraco.EmbeddedResource) installs a single assembly _Our.Umbraco.EmbeddedResource.dll_.

Using embedded resources within an assembly for a package has some of advantages:

1) No need to split a package into two NuGet packages to prevent \App_Plugins\*.* files from added into a class library project.

2) There's nothing to add into source control (other than a NuGet reference) for the end consumer.

3) Resources can be protected so that they are only served to back office authenticated users (no [leakage as to what packages are installed](https://twitter.com/jschoemaker1984/status/1004231493240213505)).


## Usage

The embedded resources in your project need to be registered and this is done via assembly attributes (typically placed in /Properties/AssemblyInfo.cs).

There are two assembly attributes: 
* [EmbeddedResourceAttribute](src/Our.Umbraco.EmbeddedResource/EmbeddedResourceAttribute.cs)
* [EmbeddedResourceProtectedAttribute](src/Our.Umbraco.EmbeddedResource/EmbeddedResourceProtectedAttribute.cs)

Both attributes have the same two required parameters:
* The full namespace path to the embedded resource
* The app relative url that the resource should be served on


## Example

    @using Our.Umbraco.EmbeddedResource

    // register an embedded jpg as if it were on the file system    
    [assembly: EmbeddedResource("MyPackage.Example.jpg", "/AppPlugins/MyPackage/Example.jpg")]
    
    // register an embedded png, served only to back office users    
    [assembly: EmbeddedResourceProtected("MyPackage.Example.png", "/AppPlugins/MyPackage/Example.png")]
