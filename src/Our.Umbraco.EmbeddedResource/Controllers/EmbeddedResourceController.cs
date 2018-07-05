using Our.Umbraco.EmbeddedResource.Services;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Security;

namespace Our.Umbraco.EmbeddedResource.Controllers
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
            var embeddedResourceItem = EmbeddedResourceService.GetServedEmbeddedResourceItem(url);

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

        /// <summary>
        /// returns true if the current request is logged in as a back office user
        /// </summary>
        /// <returns></returns>
        private bool IsBackOfficeUser()
        {
            if (this.HttpContext != null)
            {
                var context = this.HttpContext;
                var ticket = this.HttpContext.GetUmbracoAuthTicket();

                return context.AuthenticateCurrentRequest(ticket, true);
            }

            return false;
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
