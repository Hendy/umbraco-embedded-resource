using ClientDependency.Core;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;

namespace Our.Umbraco.EmbeddedResource
{
    public class EmbeddedResourceStartup : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            base.ApplicationStarted(umbracoApplication, applicationContext);

            RouteTable
                .Routes
                .MapRoute(
                    name: "nuPickersShared",
                    url: EmbeddedResourceConstants.ROOT_URL.TrimStart("~/") + "{folder}/{file}",
                    defaults: new
                    {
                        controller = "EmbeddedResource",
                        action = "GetSharedResource"
                    },
                    namespaces: new[] { "nuPickers.EmbeddedResource" });

            FileWriters.AddWriterForExtension(EmbeddedResourceConstants.FILE_EXTENSION, new EmbeddedResourceVirtualFileWriter());
        }

        protected override bool ExecuteWhenApplicationNotConfigured
        {
            get { return true; }
        }
    }
}
