# umbraco-embedded-resource
For use by package developers to serve embedded assets.

Using embedded resources within an assembly for an Umbraco package has advantage over placing them on the file system when it comes to distribution via NuGet; often a class library project will also need to make a reference to the package, and if the files are not embedded, then those unrequired files are also added into the class library project. Typically this could be resolved by splitting the Umbraco package into two separate NuGet packages (one for each project type) - so embedding resources can simplify NuGet distribution.

Usage:

The embedded resource pacakge on startup, will look for all assembly attributes of type 'EmbeddedResource', each of which specifies the namespace of an embedded rerource and the url it should be served on.

Example:

[assembly: EmbeddedResource("MyPackage.Example.jpg", "~/AppPlugins/MyPackage/Example.jpg")]

[assembly: EmbeddedResource("MyPackage.Example.png", "~/AppPlugins/MyPackage/Example.png")]

(Any files on the file system will take precenence over an embedded resource)
