using System;

namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// Register an embedded resource in this assembly so it can be served over http(s).
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class EmbeddedResourceAttribute : BaseEmbeddedResourceAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceNamespace"></param>
        /// <param name="resourceUrl"></param>
        public EmbeddedResourceAttribute(string resourceNamespace, string resourceUrl) : base(resourceNamespace, resourceUrl) { }
    }
}