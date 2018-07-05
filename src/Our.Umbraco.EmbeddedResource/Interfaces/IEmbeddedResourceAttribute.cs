namespace Our.Umbraco.EmbeddedResource.Interfaces
{
    internal interface IEmbeddedResourceAttribute
    {
        string ResourceNamespace { get; }

        string ResourceUrl { get; }
    }
}
