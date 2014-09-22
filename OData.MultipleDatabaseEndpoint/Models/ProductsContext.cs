using System.Data.Entity;

namespace OData.MultipleDatabaseEndpoint.Models
{
    public class ProductsContext : DbContext
    {
        public ProductsContext()
            : base("name=HamburgDB")
        {
        }

        public ProductsContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}