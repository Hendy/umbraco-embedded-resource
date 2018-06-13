﻿using System;

namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// Attribute to register an embedded resource 
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class EmbeddedResourceProtectedAttribute : Attribute
    {
        internal string ResourceNamespace { get; private set; }

        internal string ResourceUrl { get; private set; }

        /// <summary>
        /// Register an embedded resource in this assembly that is served only to back office authenticated users over http(s).
        /// </summary>
        /// <param name="resourceNamespace">The full namespace of the embedded resource file to register - eg. "MyProject.Folder.ExampleResource.html"</param>
        /// <param name="resourceUrl">The app relative url on which the resource file should be served - eg. "~/AppPlugins/MyProject/Folder/ExampleResource.html"</param>
        public EmbeddedResourceProtectedAttribute(string resourceNamespace, string resourceUrl)
        {
            this.ResourceNamespace = resourceNamespace;
            this.ResourceUrl = resourceUrl;
        }
    }
}