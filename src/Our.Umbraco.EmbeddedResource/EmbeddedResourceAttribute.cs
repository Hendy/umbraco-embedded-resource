using System;

namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// Attribute to use to configure the EmbeddedResource project to handle the serving of embedded resources
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class EmbeddedResourceAttribute : Attribute
    {
        /// <summary>
        /// The name of the ~/App_Plugins/{Folder}/ to handle requests for
        /// </summary>
        public string Folder { get; set; }

        /// <summary>
        /// The root namespace in this assembly from which to scan for embedded resource files
        /// (any resources in descendant namespaces will map with url sub folders)
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// An array of file extensions to handle 
        /// </summary>
        public string[] Extensions { get; set; } = new string[] { "html", "css", "js", "gif", "jpg", "png" };
    }
}