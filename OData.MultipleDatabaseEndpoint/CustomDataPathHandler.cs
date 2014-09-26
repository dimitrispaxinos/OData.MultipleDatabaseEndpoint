using System.Web.Http.OData.Routing;
using Microsoft.Data.Edm;
using OData.MultipleDatabaseEndpoint.DatabaseSetter;

namespace OData.MultipleDatabaseEndpoint
{
    public class CustomDataPathHandler : DefaultODataPathHandler
    {
        private readonly IConnectionStringSetter _connectionStringSetter;

        public CustomDataPathHandler(IConnectionStringSetter connectionStringSetter)
        {
            _connectionStringSetter = connectionStringSetter;
        }

        public override ODataPath Parse(IEdmModel model, string odataPath)
        {
            if (!odataPath.StartsWith("$") && odataPath.IndexOf("/") > 0)
            {
                var storeName = odataPath.Substring(0, odataPath.IndexOf("/"));
                var entityPath = odataPath.Substring(odataPath.IndexOf("/") + 1);
                _connectionStringSetter.SetConnectionString(storeName + "DB");
                odataPath = entityPath;
            }

            return base.Parse(model, odataPath);
        }
    }
}