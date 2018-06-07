using System.Web;
using System.Web.Mvc;

namespace Our.Umbraco.EmbeddedResource
{
    public class EmbeddedResourceController : Controller
    {
        public ActionResult GetEmbeddedResource()
        {
            var url = this.Request.Url.AbsoluteUri;

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
            var fileName = VirtualPathUtility.GetFileName(url);

            var mimeType = MimeMapping.GetMimeMapping(fileName);

            return mimeType ?? "text";
        }
    }
}
