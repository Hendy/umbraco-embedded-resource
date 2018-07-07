using ClientDependency.Core.CompositeFiles;
using Our.Umbraco.EmbeddedResource.Services;

namespace Our.Umbraco.EmbeddedResource.ClientDependency
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
            return new EmbeddedResourceService().ServedResourceExists(virtualFile);
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
                return new EmbeddedResourceVirtualFile(virtualFile);
            }

            return null;
        }
    }
}
