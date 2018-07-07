namespace Our.Umbraco.EmbeddedResource.Tests
{
    internal static class Constants
    {
        internal const string HTML_RESOURCE_URL = "~/App_Plugins/EmbeddedResourceTests/EmbeddedResource.html";

        internal const string JPG_RESOURCE_URL = "~/App_Plugins/EmbeddedResourceTests/EmbeddedResource.jpg";

        internal const string PNG_RESOURCE_URL = "~/App_Plugins/EmbeddedResourceTests/EmbeddedResource.png";

        internal const string TXT_RESOURCE_URL = "~/App_Plugins/EmbeddedResourceTests/EmbeddedResource.txt";

        /// <summary>
        /// used to test the security option
        /// </summary>
        internal const string PROTECTED_RESOURCE_URL = "~/App_Plugins/EmbeddedResourceTests/BackOfficeOnly.txt";

        /// <summary>
        /// a valid relative url, but with no corresponding embedded resource
        /// </summary>
        internal const string UNKNOWN_RESOURCE_URL = "~/App_Plugins/EmbeddedResourceTests/Unknown.txt";        
    }
}
