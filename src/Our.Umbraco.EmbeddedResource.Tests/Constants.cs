namespace Our.Umbraco.EmbeddedResource.Tests
{
    internal static class Constants
    {
        /// <summary>
        /// Full assembly name of this test project
        /// </summary>
        internal const string TEST_ASSEMBLY_FULL_NAME = "Our.Umbraco.EmbeddedResource.Tests, Version=0.3.0.0, Culture=neutral, PublicKeyToken=null";

        /// <summary>
        /// string values for namespace and url of the embedded test resources
        /// </summary>
        internal static class Resources
        {
            internal static class Txt
            {
                internal const string NAMESPACE = "Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.txt";

                internal const string URL = "~/App_Plugins/EmbeddedResourceTests/EmbeddedResource.txt";
            }

            internal static class Html
            {
                internal const string NAMESPACE = "Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.html";

                internal const string URL = "~/App_Plugins/EmbeddedResourceTests/EmbeddedResource.html";
            }

            internal static class Js
            {
                internal const string NAMEPSPACE = "Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.js";

                internal const string URL = "~/App_Plugins/EmbeddedResourceTests/EmbeddedResource.js";
            }

            internal static class Jpg
            {
                internal const string NAMESPACE = "Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.jpg";

                internal const string URL = "~/App_Plugins/EmbeddedResourceTests/EmbeddedResource.jpg";
            }

            internal static class Png
            {
                internal const string NAMESPACE = "Our.Umbraco.EmbeddedResource.Tests.EmbeddedResources.EmbeddedResource.png";

                internal const string URL = "~/App_Plugins/EmbeddedResourceTests/EmbeddedResource.png";
            }

            /// <summary>
            /// values represent a known embedded resource on it's own url
            /// </summary>
            internal static class Protected
            {
                internal const string NAMESPACE = Html.NAMESPACE; // re-purpose known valid

                internal const string URL = "~/App_Plugins/EmbeddedResourceTests/Protected.html";
            }

            /// <summary>
            /// values represent a valid url, but without any associated embedded resource
            /// </summary>
            internal static class Unknown
            {
                /// <summary>
                /// invalid namepace - no corresponding embedded resource
                /// </summary>
                internal const string NAMESPACE = "Our.Umbraco.EmbeddedResource.Tests.EmebeddedResources.Unknown"; // doesn't exist

                /// <summary>
                /// valid relative url - without corresponding embedded resource
                /// </summary>
                internal const string URL = "~/App_Plugins/EmbeddedResourceTests/Unknown.txt"; // reserved - nothing else should use this
            }
        }
    }
}
