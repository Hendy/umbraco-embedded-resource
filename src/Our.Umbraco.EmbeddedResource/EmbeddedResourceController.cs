using System.Web;
using System.Web.Mvc;
using Umbraco.Core; // todo: remove, as only used for a string extension method

namespace Our.Umbraco.EmbeddedResource
{
    public class EmbeddedResourceController : Controller
    {
        public ActionResult GetSharedResource(string folder, string file)
        {
            string fileName = file.TrimEnd(EmbeddedResourceConstants.FILE_EXTENSION);
            var resourceStream = EmbeddedResourceService.GetResource(EmbeddedResourceConstants.RESOURCE_PREFIX + folder + "." + fileName);

            if (resourceStream != null)
            {
                return new FileStreamResult(resourceStream, GetMimeType(fileName)); ;
            }

            return this.HttpNotFound();
        }

        private string GetMimeType(string resource)
        {
            var mimeType = MimeMapping.GetMimeMapping(resource);
            return mimeType ?? "text";
        }
    }
}
