using Our.Umbraco.EmbeddedResource.Services;
using System.Web;
using Umbraco.Core;

namespace Our.Umbraco.EmbeddedResource.Events
{
    public class EmbeddedResourceStartup : ApplicationEventHandler
    {
        /// <summary>
        /// Ensure this event fires, even if Umbraco requires a new install or an upgrade
        /// </summary>
        protected override bool ExecuteWhenApplicationNotConfigured => true;

        /// <summary>
        /// The Umbraco startup event handler
        /// </summary>
        /// <param name="umbracoApplication"></param>
        /// <param name="applicationContext"></param>
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            base.ApplicationStarted(umbracoApplication, applicationContext);

            this.Startup(new HttpContextWrapper(HttpContext.Current));
        }

        /// <summary>
        /// The main startup method
        /// </summary>
        private void Startup(HttpContextBase httpContext)
        {
            new EmbeddedResourceService(httpContext).RegisterResources();
        }
    }
}