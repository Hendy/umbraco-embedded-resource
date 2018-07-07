using Our.Umbraco.EmbeddedResource.Services;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Our.Umbraco.EmbeddedResource.Controllers
{
    /// <summary>
    /// Controller to handle serving the embedded resource
    /// </summary>
    public class EmbeddedResourceController : Controller
    {
        private EmbeddedResourceService _embeddedResourceService; 

        private EmbeddedResourceService EmbeddedResourceService
        {
            get
            {
                return _embeddedResourceService ?? new EmbeddedResourceService(this.HttpContext);
            }
        }

        /// <summary>
        /// Production constructor
        /// </summary>
        public EmbeddedResourceController() : base()
        {
        }

        /// <summary>
        /// Unit testing constructor
        /// </summary>
        /// <param name="embeddedResourceService">custom service to inject</param>
        internal EmbeddedResourceController(EmbeddedResourceService embeddedResourceService)
        {
            this._embeddedResourceService = embeddedResourceService;
        }

        /// <summary>
        /// Attempts to return a resource
        /// </summary>
        /// <param name="url">The (app relative) resource url</param>
        /// <returns>The resource or HttpNotFound</returns>
        public ActionResult GetEmbeddedResource(string url) // rename to served
        {
            var embeddedResourceItem = this.EmbeddedResourceService.GetServedEmbeddedResourceItem(url);

            if (embeddedResourceItem != null)
            {
                if (!embeddedResourceItem.BackOfficeUserOnly || this.EmbeddedResourceService.IsBackOfficeUser())
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
