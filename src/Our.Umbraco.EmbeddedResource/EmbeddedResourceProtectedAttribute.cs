using Our.Umbraco.EmbeddedResource.Interfaces;
using System;

namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// Register an embedded resource in this assembly that is served only to back office authenticated users over http(s).
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class EmbeddedResourceProtectedAttribute : Attribute, IEmbeddedResourceAttribute
    {
        /// <summary>
        /// The full namespace of the embedded resource file to register - eg. "MyProject.Folder.ExampleResource.html"
        /// </summary>
        private string _resourceNamespace;

        /// <summary>
        /// The app relative url on which the resource file should be served - eg. "~/AppPlugins/MyProject/Folder/ExampleResource.html"
        /// </summary>
        private string _resourceUrl;

        string IEmbeddedResourceAttribute.ResourceNamespace => this._resourceNamespace;

        string IEmbeddedResourceAttribute.ResourceUrl => this._resourceUrl;

        /// <summary>
        /// Register an embedded resource in this assembly that is served only to back office authenticated users over http(s).
        /// </summary>
        /// <param name="resourceNamespace">The full namespace of the embedded resource file to register - eg. "MyProject.Folder.ExampleResource.html"</param>
        /// <param name="resourceUrl">The app relative url on which the resource file should be served - eg. "~/AppPlugins/MyProject/Folder/ExampleResource.html"</param>
        public EmbeddedResourceProtectedAttribute(string resourceNamespace, string resourceUrl)
        {
            this._resourceNamespace = resourceNamespace;
            this._resourceUrl = resourceUrl;
        }
    }
}