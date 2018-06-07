﻿using System;

namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// Attribe to use to register a single embedded resource to a url
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class EmbeddedResourceAttribute : Attribute
    {
        private string resourceNamespace;

        private string resourceUrl;

        /// <summary>
        /// Register an embedded resource in this assembly so it can be served over http(s).
        /// </summary>
        /// <param name="resourceNamespace">The full namespace of the embedded resource file to register - eg. "MyProject.Folder.ExampleResource.html"</param>
        /// <param name="resourceUrl">The app relative url on which the resource file should be served - eg. "~/AppPlugins/MyProject/Folder/ExampleResource.html"</param>
        public EmbeddedResourceAttribute(string resourceNamespace, string resourceUrl)
        {
            this.resourceNamespace = resourceNamespace;
            this.resourceUrl = resourceUrl;
        }
    }
}