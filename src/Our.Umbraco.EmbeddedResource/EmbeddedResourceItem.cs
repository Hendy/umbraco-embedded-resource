namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// lightweight POCO to represent a single emebedded resource item
    /// </summary>
    public class EmbeddedResourceItem
    {
        internal string AssemblyFullName { get; private set; }

        internal string ResourceNamespace { get; private set; }

        internal string ResourceUrl { get; private set; }

        /// <summary>
        /// constructor to set property values - ensures all mandatory values are supplied
        /// </summary>
        /// <param name="resourceNamespace"></param>
        /// <param name="resourceUrl"></param>
        internal EmbeddedResourceItem(string assemblyFullName, string resourceNamespace, string resourceUrl)
        {
            this.AssemblyFullName = assemblyFullName;
            this.ResourceNamespace = resourceNamespace;
            this.ResourceUrl = resourceUrl;
        }
    }
}
