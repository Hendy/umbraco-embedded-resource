﻿using ClientDependency.Core.CompositeFiles;
using System;

namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class EmbeddedResourceVirtualFileProvider : IVirtualFileProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="virtualFile"></param>
        /// <returns></returns>
        public bool FileExists(string virtualFile)
        {
            if (!virtualFile.EndsWith(EmbeddedResourceConstants.FILE_EXTENSION, StringComparison.InvariantCultureIgnoreCase)) return false;

            string resourceName = EmbeddedResourceHelper.GetResourceNameFromPath(virtualFile);

            return EmbeddedResourceHelper.ResourceExists(resourceName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="virtualFile"></param>
        /// <returns></returns>
        public IVirtualFile GetFile(string virtualFile)
        {
            if (!FileExists(virtualFile)) return null;

            return new EmbeddedResourceVirtualFile(virtualFile);
        }
    }
}
