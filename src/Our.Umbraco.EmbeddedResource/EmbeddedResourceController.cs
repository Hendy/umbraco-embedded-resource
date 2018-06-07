using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Our.Umbraco.EmbeddedResource
{
    public class EmbeddedResourceController : Controller
    {
        public ActionResult GetEmbeddedResource()
        {
            var url = this.Request.Url.AbsoluteUri;
            var fileName = Path.GetFileName(url);

            var resourceStream = EmbeddedResourceService.GetResourceStream(url);
            
            if (resourceStream != null)
            {
                return new FileStreamResult(resourceStream, this.GetMimeType(fileName));
            }

            return this.HttpNotFound();
        }

        private string GetMimeType(string fileName)
        {
            var mimeType = MimeMapping.GetMimeMapping(fileName);
            return mimeType ?? "text";
        }
    }
}
