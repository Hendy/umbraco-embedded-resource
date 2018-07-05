using ClientDependency.Core.CompositeFiles;

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
            return EmbeddedResourceService.ServedResourceExists(virtualFile);
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
