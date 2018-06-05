# umbraco-embedded-resource
For use by package developers to serve embedded assets.

Using embedded resources within an assembly has a number of advanages:

1) No files to deploy into '~/App_Plugins/{Folder}/' - only dlls, so simplier deployment & removal.
2) Files can be put in '~/App_Plugins/{Folder}/' which will take precedence of any embedded files, so can customise (fix things) on per project basis.
3) Umbraco packages likely contain both resource files and model file that need to be referenced by class library projects - this typically means two NuGet packages so as to split the models from the resource files (to avoid the rogue '~/App_plugins/{Folder}' files from being created), so sinlge NuGet package.


Usage:

The emebdded resource pacakge on startup, will look for all assembly attributes (see below) and then then scan those assemblies for embedded resources, and then map  their urls accordingly.

[assembly: EmbeddedResource("{Folder}", "Our.Umbraco.{Package}", new string[] { "html", "css", "js" })]
