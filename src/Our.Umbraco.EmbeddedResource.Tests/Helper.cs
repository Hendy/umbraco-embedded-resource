using System.IO;

namespace Our.Umbraco.EmbeddedResource.Tests
{
    internal static class Helper
    {
        /// <summary>
        /// Replacement method for HttpContext.Server.MapPath
        /// </summary>
        /// <param name="path"></param>
        internal static string MapPath(string path)
        {
            var tempPath = Path.GetTempPath() + "Our.Umbraco.EmbeddedResource\\";

            return path
                    .Replace("~/", tempPath)
                    .Replace("/", "\\");
        }
    }
}
