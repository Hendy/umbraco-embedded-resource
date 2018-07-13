namespace Our.Umbraco.EmbeddedResource.Interfaces
{
    internal interface IEmbeddedResourceAttribute
    {
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
