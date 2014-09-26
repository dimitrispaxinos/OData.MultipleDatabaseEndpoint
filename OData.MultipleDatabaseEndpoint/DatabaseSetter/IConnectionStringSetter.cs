namespace OData.MultipleDatabaseEndpoint.DatabaseSetter
{
    public interface IConnectionStringSetter : IConnectionStringProvider
    {
        void SetConnectionString(string storeName);
    }
}