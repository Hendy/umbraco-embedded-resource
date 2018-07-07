﻿using ClientDependency.Core;
using ClientDependency.Core.CompositeFiles;
using ClientDependency.Core.CompositeFiles.Providers;
using System;
using System.IO;
using System.Web;
using Umbraco.Core.Logging;

namespace Our.Umbraco.EmbeddedResource.ClientDependency
{
    /// <summary>
    /// The embedded resource writer.
    /// </summary>
    public sealed class EmbeddedResourceVirtualFileWriter : IVirtualFileWriter
    {
        public bool WriteToStream(
                        BaseCompositeFileProcessingProvider provider, 
                        StreamWriter streamWriter, 
                        IVirtualFile virtualFile, 
                        ClientDependencyType type, 
                        string originalUrl, 
                        HttpContextBase httpContext)
        {
            try
            {
                using (var readStream = virtualFile.Open())
                using (var streamReader = new StreamReader(readStream))
                {
                    var output = streamReader.ReadToEnd();
                    DefaultFileWriter.WriteContentToStream(provider, streamWriter, output, type, httpContext, originalUrl);
                    return true;
                }
            }
            catch (Exception exception)
            {
                LogHelper.Warn(typeof(EmbeddedResourceVirtualFileWriter), exception.Message);

                return false;
            }
        }

        /// <summary>
        /// Gets the file provider.
        /// </summary>
        public IVirtualFileProvider FileProvider => new EmbeddedResourceVirtualFileProvider();
    }
}
