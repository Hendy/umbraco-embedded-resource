﻿using System;

namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// Attribe to register an embedded resource
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class EmbeddedResourceAttribute : Attribute
    {
        internal string ResourceNamespace { get; private set; }

        internal string ResourceUrl { get; private set; }

        internal bool BackOfficeUserOnly { get; private set; }

        /// <summary>
        /// Register an embedded resource in this assembly so it can be served over http(s).
        /// </summary>
        /// <param name="resourceNamespace">The full namespace of the embedded resource file to register - eg. "MyProject.Folder.ExampleResource.html"</param>
        /// <param name="resourceUrl">The app relative url on which the resource file should be served - eg. "~/AppPlugins/MyProject/Folder/ExampleResource.html"</param>
        /// <param name="backOfficeUserOnly">When true, this resource will only be served to a user logged into the back office</param>
        public EmbeddedResourceAttribute(string resourceNamespace, string resourceUrl, bool backOfficeUserOnly = false)
        {
            this.ResourceNamespace = resourceNamespace;
            this.ResourceUrl = resourceUrl;
            this.BackOfficeUserOnly = backOfficeUserOnly;
        }
    }
}