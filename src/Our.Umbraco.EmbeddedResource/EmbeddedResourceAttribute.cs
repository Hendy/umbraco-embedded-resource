using System;

namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// Attribe to use to register a single embedded resource to a url
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class EmbeddedResourceAttribute : Attribute
    {
        private string resourceNamespace;

        private string resourceUrl;

        public EmbeddedResourceAttribute(string resourceNamespace, string resourceUrl)
        {
            this.resourceNamespace = resourceNamespace;
            this.resourceUrl = resourceUrl;
        }
    }
}