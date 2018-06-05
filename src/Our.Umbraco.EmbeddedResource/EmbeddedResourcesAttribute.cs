using System;

namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// Attribute to use to configure multiple embedded resources to be served on urls
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public class EmbeddedResourcesAttribute : Attribute
    {
        /// <summary>
        /// The root namespace in this assembly from which to scan for embedded resource files
        /// (any resources in descendant namespaces will map with url sub folders)
        /// </summary>
        private string rootNamespace;

        /// <summary>
        /// The root url, (expected to be "~/App_Plugins/{project}/")
        /// </summary>
        private string rootUrl;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootNamespace"></param>
        /// <param name="rootUrl"></param>
        public EmbeddedResourcesAttribute(string rootNamespace, string rootUrl)
        {
            this.rootNamespace = rootNamespace;
            this.rootUrl = rootUrl; ;
        }
    }
}