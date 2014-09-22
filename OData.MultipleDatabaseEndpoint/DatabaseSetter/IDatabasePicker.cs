namespace OData.MultipleDatabaseEndpoint.DatabaseSetter
{
    public interface IDatabasePicker
    {
        string GetConnectionString();
    }
}