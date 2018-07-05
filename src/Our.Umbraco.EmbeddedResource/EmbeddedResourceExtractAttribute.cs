using Our.Umbraco.EmbeddedResource.Interfaces;
using System;

namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// Register an embedded resource in this assembly so it it extracted onto the file-system by path mapping from an app relative url
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class EmbeddedResourceExtractAttribute : Attribute, IEmbeddedResourceAttribute
    {
        /// <summary>
        /// The full namespace of the embedded resource file to register - eg. "MyProject.Folder.ExampleResource.html"<
        /// </summary>
        private string ResourceNamespace;

        /// <summary>
        /// The app relative url on which the resource file should map to the file system from - eg. "~/AppPlugins/MyProject/Folder/ExampleResource.html"
        /// </summary>
        private string ResourceUrl;

        string IEmbeddedResourceAttribute.ResourceNamespace => this.ResourceNamespace;

        string IEmbeddedResourceAttribute.ResourceUrl => this.ResourceUrl;

        /// <summary>
        /// Register an embedded resource in this assembly so it it extracted onto the file-system by path mapping from an app relative url
        /// </summary>
        /// <param name="resourceNamespace">The full namespace of the embedded resource file to register - eg. "MyProject.Folder.ExampleResource.html"</param>
        /// <param name="resourceUrl">The app relative url then mapped to the file-system where the resource file should be saved - eg. "~/AppPlugins/MyProject/Folder/ExampleResource.html"</param>
        public EmbeddedResourceExtractAttribute(string resourceNamespace, string resourceUrl)
        {
            this.ResourceNamespace = resourceNamespace;
            this.ResourceUrl = resourceUrl;
        }
    }
}