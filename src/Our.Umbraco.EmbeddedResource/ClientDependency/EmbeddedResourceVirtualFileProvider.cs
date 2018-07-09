using ClientDependency.Core.CompositeFiles;
using Our.Umbraco.EmbeddedResource.Services;

namespace Our.Umbraco.EmbeddedResource.ClientDependency
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class EmbeddedResourceVirtualFileProvider : IVirtualFileProvider
    {
        private EmbeddedResourceService _embeddedResourceService;

        /// <summary>
        /// Constructor to inject service
        /// </summary>
        /// <param name="embeddedResourceService"></param>
        internal EmbeddedResourceVirtualFileProvider(EmbeddedResourceService embeddedResourceService)
        {
            this._embeddedResourceService = embeddedResourceService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="virtualFile"></param>
        /// <returns></returns>
        public bool FileExists(string virtualFile)
        {
            return this._embeddedResourceService.ServedResourceExists(virtualFile);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="virtualFile"></param>
        /// <returns></returns>
        public IVirtualFile GetFile(string virtualFile)
        {
            if (this.FileExists(virtualFile))
            {
                return new EmbeddedResourceVirtualFile(this._embeddedResourceService, virtualFile);
            }

            return null;
        }
    }
}
