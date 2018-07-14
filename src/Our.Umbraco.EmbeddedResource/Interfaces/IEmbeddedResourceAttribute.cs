namespace Our.Umbraco.EmbeddedResource.Interfaces
{
    /// <summary>
    /// The min set of data required to identify a resource
    /// </summary>
    internal interface IEmbeddedResourceAttribute
    {
        /// <summary>
        /// The full name of the assembly in which the resource is in
        /// </summary>
        string AssemblyFullName { get; }

        /// <summary>
        /// The namespace to the resource
        /// </summary>
        string ResourceNamespace { get; }

        /// <summary>
        /// The url on which it should be served, or mapped to the file-system for extraction
        /// </summary>
        string ResourceUrl { get; }
    }
}
