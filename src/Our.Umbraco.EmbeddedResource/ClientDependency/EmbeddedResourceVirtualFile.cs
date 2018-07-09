using ClientDependency.Core.CompositeFiles;
using Our.Umbraco.EmbeddedResource.Services;
using System.IO;

namespace Our.Umbraco.EmbeddedResource.ClientDependency
{
    /// <summary>
    /// The embedded resource virtual file.
    /// </summary>
    internal class EmbeddedResourceVirtualFile : IVirtualFile
    {
        private EmbeddedResourceService _embeddedResourceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedResourceVirtualFile"/> class. 
        /// Initializes a new instance of the <see cref="T:System.Web.Hosting.VirtualFile"/> class. 
        /// </summary>
        /// <param name="virtualFile">
        /// The virtual path to the resource represented by this instance. 
        /// </param>
        internal EmbeddedResourceVirtualFile(EmbeddedResourceService embeddedResourceService, string virtualFile)
        {
            this.Path = virtualFile;
            this._embeddedResourceService = embeddedResourceService;
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// When overridden in a derived class, returns a read-only stream to the virtual resource.
        /// </summary>
        /// <returns>
        /// A read-only stream to the virtual file.
        /// </returns>
        public Stream Open()
        {
            return this._embeddedResourceService.GetServedResourceStream(this.Path);
        }
    }
}
