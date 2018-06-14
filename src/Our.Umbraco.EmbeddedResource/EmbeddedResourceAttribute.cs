using System;

namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// Attribe to register an embedded resource
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class EmbeddedResourceAttribute : Attribute, IEmbeddedResourceAttribute
    {
        private string ResourceNamespace;

        private string ResourceUrl;

        string IEmbeddedResourceAttribute.ResourceNamespace => this.ResourceNamespace;

        string IEmbeddedResourceAttribute.ResourceUrl => this.ResourceUrl;

        /// <summary>
        /// Register an embedded resource in this assembly so it can be served over http(s).
        /// </summary>
        /// <param name="resourceNamespace">The full namespace of the embedded resource file to register - eg. "MyProject.Folder.ExampleResource.html"</param>
        /// <param name="resourceUrl">The app relative url on which the resource file should be served - eg. "~/AppPlugins/MyProject/Folder/ExampleResource.html"</param>
        public EmbeddedResourceAttribute(string resourceNamespace, string resourceUrl)
        {
            this.ResourceNamespace = resourceNamespace;
            this.ResourceUrl = resourceUrl;
        }

        /// <summary>
        /// Register an embedded resource in this assembly so it can be served over http(s).
        /// </summary>
        /// <param name="resourceNamespace">The full namespace of the embedded resource file to register - eg. "MyProject.Folder.ExampleResource.html"</param>
        /// <param name="resourceUrl">The app relative url on which the resource file should be served - eg. "~/AppPlugins/MyProject/Folder/ExampleResource.html"</param>
        /// <param name="backOfficeUserOnly">When true, this resource will only be served to a user logged into the back office</param>
        [Obsolete("This overload wil be removed in 0.3.0")]
        public EmbeddedResourceAttribute(string resourceNamespace, string resourceUrl, bool backOfficeUserOnly = false)
        {
            this.ResourceNamespace = resourceNamespace;
            this.ResourceUrl = resourceUrl;
        }
    }
}