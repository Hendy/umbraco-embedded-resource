using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Our.Umbraco.EmbeddedResource
{
    public class EmbeddedResourceController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">passed in to avoid using the http context</param>
        /// <returns></returns>
        public ActionResult GetEmbeddedResource(string url)
        {
            var resourceStream = EmbeddedResourceService.GetResourceStream(url);
            
            if (resourceStream != null)
            {
                return new FileStreamResult(resourceStream, this.GetMimeType(url));
            }

            return this.HttpNotFound();
        }

        /// <summary>
        /// Helper to get the mime type from file extension
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetMimeType(string url)
        {
            var fileName = Path.GetFileName(url);

            var mimeType = MimeMapping.GetMimeMapping(fileName);

            return mimeType ?? "text";
        }
    }
}
