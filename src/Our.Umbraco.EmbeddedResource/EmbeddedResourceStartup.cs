using ClientDependency.Core;
using System;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;
using System.Linq;

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
        /// Main startup method - scan for embedded resources and wire up routing to serve them
        /// </summary>
        private void Startup()
        {
            // TODO: reflect to find all usages of the EmbeddedResourceAttribute
            Assembly[] assemblies = AppDomain
                                    .CurrentDomain
                                    .GetAssemblies()
                                    .Where(x => x.GetCustomAttributes<EmbeddedResourceAttribute>().Any())
                                    .ToArray();

            

            RouteTable
                .Routes
                .MapRoute(
                    name: "EmbeddedResource" + Guid.NewGuid().ToString(),
                    url: EmbeddedResourceConstants.ROOT_URL.TrimStart("~/") + "{folder}/{file}",
                    defaults: new
                    {
                        controller = "EmbeddedResource",
                        action = "GetSharedResource"
                    },
                    namespaces: new[] { "nuPickers.EmbeddedResource" });

            FileWriters.AddWriterForExtension(EmbeddedResourceConstants.FILE_EXTENSION, new EmbeddedResourceVirtualFileWriter());
        }

        /// <summary>
        /// used by the unit testing project
        /// </summary>
        private void Shutdown()
        {
            RouteTable.Routes.Clear();
        }
    }
}
