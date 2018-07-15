﻿using Our.Umbraco.EmbeddedResource.Interfaces;

namespace Our.Umbraco.EmbeddedResource.Models
{
    /// <summary>
    /// lightweight POCO to represent a single emebedded resource
    /// </summary>
    public class EmbeddedResourceItem // : IEmbeddedResource
    {
        internal string AssemblyFullName { get; private set; }

        internal string ResourceNamespace { get; private set; }

        internal string ResourceUrl { get; private set; }

        internal bool BackOfficeUserOnly { get; private set; }

        internal bool ExtractToFileSystem { get; private set; }

        //string IEmbeddedResource.AssemblyFullName => throw new System.NotImplementedException();

        //string IEmbeddedResource.ResourceNamespace => throw new System.NotImplementedException();

        //string IEmbeddedResource.ResourceUrl => throw new System.NotImplementedException();

        /// <summary>
        /// internal constructor to ensure all mandatory values supplied
        /// </summary>
        /// <param name="resourceNamespace"></param>
        /// <param name="resourceUrl"></param>
        internal EmbeddedResourceItem(
            string assemblyFullName, 
            string resourceNamespace, 
            string resourceUrl, 
            bool backOfficeUserOnly,
            bool extractToFileSystem)
        {
            this.AssemblyFullName = assemblyFullName;
            this.ResourceNamespace = resourceNamespace;
            this.ResourceUrl = resourceUrl;
            this.BackOfficeUserOnly = backOfficeUserOnly;
            this.ExtractToFileSystem = extractToFileSystem;
        }
    }
}
