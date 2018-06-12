# Umbraco Embedded Resource
For use by package developers to serve embedded assets.

Using embedded resources within an assembly for an Umbraco package has a number of advantages over placing them on the file system.

1) No need to split a package into two NuGet packages; often a class library project will also need to make a reference to the package, and if the files are not embedded, then those unnecessary files are also added into the class library project.

2) Without resrouce files on the file system, there's nothing to add (other than the NuGet reference) into source control.

3) Resources can be protected such that they are only served to back office authenticated users.


Usage:

The embedded resource pacakge on startup, will look for all assembly attributes of type 'EmbeddedResource', each of which specifies the namespace of an embedded rerource, the url it should be served on, and whether it should be protected.

Example:

  [assembly: EmbeddedResource("MyPackage.Example.jpg", "/AppPlugins/MyPackage/Example.jpg", false)] // public
  
  [assembly: EmbeddedResource("MyPackage.Example.png", "/AppPlugins/MyPackage/Example.png", true)] // back office users only
