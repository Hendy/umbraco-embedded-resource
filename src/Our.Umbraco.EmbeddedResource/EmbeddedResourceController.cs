using System.IO;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web;

namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// Controller to handle serving the embedded resource
    /// </summary>
    public class EmbeddedResourceController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">The (app relative) resource url (passed in to avoid using the http context)</param>
        /// <returns></returns>
        public ActionResult GetEmbeddedResource(string url)
        {
            var embeddedResourceItem = EmbeddedResourceService.GetEmbeddedResourceItem(url);

            if (embeddedResourceItem != null)
            {
                if (!embeddedResourceItem.BackOfficeUserOnly || this.IsBackOfficeUser())
                {
                    var resourceStream = EmbeddedResourceService.GetResourceStream(embeddedResourceItem);

                    if (resourceStream != null)
                    {
                        return new FileStreamResult(resourceStream, this.GetMimeType(url));
                    }
                }
            }

            return this.HttpNotFound();
        }

        private bool IsBackOfficeUser()
        {
            return UmbracoContext.Current.Security.CurrentUser != null;
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
