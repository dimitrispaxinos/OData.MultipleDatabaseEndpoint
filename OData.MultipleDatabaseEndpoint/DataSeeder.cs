using System.Data.Entity.Migrations;
using OData.MultipleDatabaseEndpoint.Models;

namespace OData.MultipleDatabaseEndpoint
{
    public static class DataSeeder
    {
        public static void CreateData()
        {
            CreateBerlinData();
            CreateHamburgData();
        }

        private static void CreateHamburgData()
        {
            var context = new ProductsContext("name=HamburgDB");
            context.Database.Initialize(true);

            context.Products.AddRange(new Product[]
            {
                new Product() {Id = 1, Name = "Hat", Price = 15, Category = "Apparel", Location = "Hamburg"},
                new Product() {Id = 2, Name = "Socks", Price = 5, Category = "Apparel", Location = "Hamburg"},
                new Product() {Id = 3, Name = "Scarf", Price = 12, Category = "Apparel", Location = "Hamburg"},
                new Product() {Id = 4, Name = "Yo-yo", Price = 4.95M, Category = "Toys", Location = "Hamburg"},
                new Product() {Id = 5, Name = "Puzzle", Price = 8, Category = "Toys", Location = "Hamburg"},
            });
            context.SaveChanges();
        }

        private static void CreateBerlinData()
        {
            var context = new ProductsContext("name=BerlinDB");
            context.Database.Initialize(true);
            context.Products.AddOrUpdate(new Product[]
            {
                new Product() {Id = 1, Name = "Hat", Price = 15, Category = "Apparel", Location = "Berlin"},
                new Product() {Id = 2, Name = "Socks", Price = 5, Category = "Apparel", Location = "Berlin"},
                new Product() {Id = 3, Name = "Scarf", Price = 12, Category = "Apparel", Location = "Berlin"},
                new Product() {Id = 4, Name = "Yo-yo", Price = 4.95M, Category = "Toys", Location = "Berlin"},
                new Product() {Id = 5, Name = "Puzzle", Price = 8, Category = "Toys", Location = "Berlin"},
            });
            context.SaveChanges();
        }
    }
}