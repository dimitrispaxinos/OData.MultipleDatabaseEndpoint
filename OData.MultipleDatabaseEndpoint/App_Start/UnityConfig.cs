using System.Web.Http;
using Microsoft.Practices.Unity;
using OData.MultipleDatabaseEndpoint.DatabaseSetter;
using Unity.WebApi;

namespace OData.MultipleDatabaseEndpoint
{
    public static class UnityConfig
    {
        public static UnityContainer UnityContainer { get; set; }

        public static void RegisterComponents()
        {
            UnityContainer = new UnityContainer();
            var databaseSetter = new DatabaseSetter.ConnectionStringSetter();

            UnityContainer.RegisterInstance<IConnectionStringSetter>(databaseSetter);
            UnityContainer.RegisterInstance<IConnectionStringProvider>(databaseSetter);
            UnityContainer.RegisterType<CustomDataPathHandler>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(UnityContainer);
        }
    }
}