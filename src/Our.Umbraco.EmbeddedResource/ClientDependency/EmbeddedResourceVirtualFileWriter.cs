using ClientDependency.Core;
using ClientDependency.Core.CompositeFiles;
using ClientDependency.Core.CompositeFiles.Providers;
using Our.Umbraco.EmbeddedResource.Services;
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
        private EmbeddedResourceService _embeddedResourceService;

        /// <summary>
        /// Constructor to inject service
        /// </summary>
        /// <param name="embeddedResourceService"></param>
        internal EmbeddedResourceVirtualFileWriter(EmbeddedResourceService embeddedResourceService)
        {
            this._embeddedResourceService = embeddedResourceService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="streamWriter"></param>
        /// <param name="virtualFile"></param>
        /// <param name="clientDependencyType"></param>
        /// <param name="originalUrl"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public bool WriteToStream(
                        BaseCompositeFileProcessingProvider provider, 
                        StreamWriter streamWriter, 
                        IVirtualFile virtualFile, 
                        ClientDependencyType clientDependencyType, 
                        string originalUrl, 
                        HttpContextBase httpContext)
        {
            try
            {
                using (var readStream = virtualFile.Open())
                using (var streamReader = new StreamReader(readStream))
                {
                    var output = streamReader.ReadToEnd();
                    DefaultFileWriter.WriteContentToStream(provider, streamWriter, output, clientDependencyType, httpContext, originalUrl);
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
        public IVirtualFileProvider FileProvider => new EmbeddedResourceVirtualFileProvider(this._embeddedResourceService);
    }
}
