using ClientDependency.Core;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;

namespace Our.Umbraco.EmbeddedResource
{
    public class EmbeddedResourceStartup : ApplicationEventHandler
    {
        /// <summary>
        /// Ensure this event fires, even if Umbraco requires a new install or an upgrade
        /// </summary>
        protected override bool ExecuteWhenApplicationNotConfigured
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// The Umbraco startup event handler
        /// </summary>
        /// <param name="umbracoApplication"></param>
        /// <param name="applicationContext"></param>
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            base.ApplicationStarted(umbracoApplication, applicationContext);

            this.Startup();
        }

        /// <summary>
        /// The main startup method
        /// </summary>
        private void Startup()
        {
            foreach (var embeddedResourceItem in EmbeddedResourceService.GetEmbeddedResourceItems())
            {
                // register with mvc
                RouteTable
                    .Routes
                    .MapRoute(
                        name: "EmbeddedResource" + Guid.NewGuid().ToString(),
                        url: embeddedResourceItem.ResourceUrl.TrimStart("~/"), // forward slash always expected
                        defaults: new
                        {
                            controller = "EmbeddedResource",
                            action = "GetEmbeddedResource",
                            url = embeddedResourceItem.ResourceUrl
                        },
                        namespaces: new[] { "Our.Umbraco.EmbeddedResource" });

                // register with client depenedency
                FileWriters.AddWriterForFile(embeddedResourceItem.ResourceUrl.TrimStart('~'), new EmbeddedResourceVirtualFileWriter());
            }
        }
    }
}