namespace Our.Umbraco.EmbeddedResource
{
    internal interface IEmbeddedResourceAttribute
    {
        string ResourceNamespace { get; }

        string ResourceUrl { get; }
    }
}
