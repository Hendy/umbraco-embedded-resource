using System;

namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// Register an embedded resource in this assembly that is served only to back office authenticated users over http(s).
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class EmbeddedResourceProtectedAttribute : BaseEmbeddedResourceAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceNamespace"></param>
        /// <param name="resourceUrl"></param>
        public EmbeddedResourceProtectedAttribute(string resourceNamespace, string resourceUrl) : base(resourceNamespace, resourceUrl) { }
    }
}