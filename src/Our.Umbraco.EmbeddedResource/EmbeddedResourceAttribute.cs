using System;

namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// Attribute to use to configure the EmbeddedResource project to handle the serving of embedded resources
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class EmbeddedResourceAttribute : Attribute
    {
        public EmbeddedResourceAttribute(string appPluginsChildFolder, string rootNamespace, string[] fileExtensions)
        {
            // = new string[] { "html", "css", "js", "gif", "jpg", "png" }

            this.appPluginsChildFolder = appPluginsChildFolder;
            this.rootNamespace = rootNamespace;
        }

        /// <summary>
        /// The name of the ~/App_Plugins/{AppPluginsChildFolder}/ to handle requests for
        /// </summary>
        private string appPluginsChildFolder;

        /// <summary>
        /// The root namespace in this assembly from which to scan for embedded resource files
        /// (any resources in descendant namespaces will map with url sub folders)
        /// </summary>
        private string rootNamespace;

        /// <summary>
        /// An array of file extensions to handle 
        /// </summary>
        private string[] fileExtensions;
    }
}