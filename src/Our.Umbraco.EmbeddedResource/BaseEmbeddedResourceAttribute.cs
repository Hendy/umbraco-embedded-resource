﻿using Our.Umbraco.EmbeddedResource.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Our.Umbraco.EmbeddedResource
{
    public abstract class BaseEmbeddedResourceAttribute : Attribute, IEmbeddedResource
    {
        private string _assemblyFullName;

        private string _resourceNamespace;

        private string _resourceUrl;

        string IEmbeddedResource.AssemblyFullName => this._assemblyFullName;

        string IEmbeddedResource.ResourceNamespace => this._resourceNamespace;

        string IEmbeddedResource.ResourceUrl => this._resourceUrl;

        /// <summary>
        /// Register an embedded resource in this assembly.
        /// </summary>
        /// <param name="resourceNamespace">The full namespace of the embedded resource file to register - eg. "MyProject.Folder.ExampleResource.html"</param>
        /// <param name="resourceUrl">The app relative url on which the resource file should be served or mapped to the file-system - eg. "~/AppPlugins/MyProject/Folder/ExampleResource.html"</param>
        public BaseEmbeddedResourceAttribute(string resourceNamespace, string resourceUrl)
        {
            // SLOW CODE (but only used in startup) caculating in the constuctor here, means can avoid a further call to a setter
            var currentAssembly = Assembly.GetExecutingAssembly();
            var callingAssemblies = new StackTrace()
                                        .GetFrames()
                                        .Select(x => x.GetMethod().ReflectedType.Assembly)
                                        .Distinct()
                                        .Where(x => x.GetReferencedAssemblies().Any(y => y.FullName == currentAssembly.FullName));

            this._assemblyFullName = callingAssemblies.Last().FullName;
            this._resourceNamespace = resourceNamespace;
            this._resourceUrl = resourceUrl;
        }

    }
}