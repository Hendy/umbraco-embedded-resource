using ClientDependency.Core;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;

namespace Our.Umbraco.EmbeddedResource
{
    /// <summary>
    /// singleton wrapper used to hold onto a 'started' state (so multiple calls to startup only trigger it once)
    /// </summary>
    internal sealed class EmbeddedResourceStartup
    {
        private static readonly Lazy<EmbeddedResourceStartup> embeddedResourceStartup = new Lazy<EmbeddedResourceStartup>(() => new EmbeddedResourceStartup());

        private bool started = false;

        internal static EmbeddedResourceStartup Instance
        {
            get
            {
                return embeddedResourceStartup.Value;
            }
        }

        private EmbeddedResourceStartup()
        {
        }
        
        internal void Startup()
        {
            if (!this.started)
            {
                this.started = true;

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
                                action = "GetEmbeddedResource"
                            },
                            namespaces: new[] { "Our.Umbraco.EmbeddedResource" });

                    // register with client depenedency
                    FileWriters.AddWriterForFile(embeddedResourceItem.ResourceUrl.TrimStart('~'), new EmbeddedResourceVirtualFileWriter());
                }
            }
        }
    }
}
