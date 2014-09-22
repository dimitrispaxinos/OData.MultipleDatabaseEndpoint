namespace OData.MultipleDatabaseEndpoint.DatabaseSetter
{
    public class DatabaseSetter : IDatabaseSetter
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