namespace OData.MultipleDatabaseEndpoint.DatabaseSetter
{
    public interface IDatabaseSetter : IDatabasePicker
    {
        void SetConnectionString(string storeName);
    }
}