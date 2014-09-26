using System.Data.Entity;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Routing.Conventions;
using Microsoft.Practices.Unity;
using OData.MultipleDatabaseEndpoint.Models;

namespace OData.MultipleDatabaseEndpoint
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ProductsContext>());
            
            //Create sample data for the demo
            DataSeeder.CreateData();

            UnityConfig.RegisterComponents();

            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");

            config.Routes.MapODataRoute(
                routeName: "odata",
                routePrefix: "odata",
               model: builder.GetEdmModel(),
               pathHandler: UnityConfig.UnityContainer.Resolve<CustomDataPathHandler>(),
               routingConventions: ODataRoutingConventions.CreateDefault());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
