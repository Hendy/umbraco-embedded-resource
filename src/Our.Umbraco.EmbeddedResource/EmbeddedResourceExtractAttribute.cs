using System;

namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// Register an embedded resource in this assembly so it it extracted onto the file-system by path mapping from an app relative url
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class EmbeddedResourceExtractAttribute : BaseEmbeddedResourceAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceNamespace"></param>
        /// <param name="resourceUrl"></param>
        public EmbeddedResourceExtractAttribute(string resourceNamespace, string resourceUrl) : base(resourceNamespace, resourceUrl) { }
    }
}