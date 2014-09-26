namespace OData.MultipleDatabaseEndpoint.DatabaseSetter
{
    public class ConnectionStringSetter : IConnectionStringSetter
    {
        public string StoreName { get; private set; }

        public void SetConnectionString(string storeName)
        {
            StoreName = storeName;
        }

        public string GetConnectionString()
        {
            return StoreName;
        }
    }
}