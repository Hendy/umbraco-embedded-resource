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
        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedResourceVirtualFile"/> class. 
        /// Initializes a new instance of the <see cref="T:System.Web.Hosting.VirtualFile"/> class. 
        /// </summary>
        /// <param name="virtualFile">
        /// The virtual path to the resource represented by this instance. 
        /// </param>
        public EmbeddedResourceVirtualFile(string virtualFile)
        {
            this.Path = virtualFile;
        }

        /// <summary>
        /// When overridden in a derived class, returns a read-only stream to the virtual resource.
        /// </summary>
        /// <returns>
        /// A read-only stream to the virtual file.
        /// </returns>
        public Stream Open()
        {
            return new EmbeddedResourceService().GetServedResourceStream(this.Path);
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        public string Path { get; }
    }
}
