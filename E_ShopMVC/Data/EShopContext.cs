
using E_ShopMVC.Models;

namespace E_ShopMVC.Data
{
    using System.Data.Entity;

    public class EShopContext : DbContext
    {
        // Your context has been configured to use a 'EShopContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'E_ShopMVC.Models.Products.EShopContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EShopContext' 
        // connection string in the application configuration file.
        public EShopContext()
            : base("name=EShopContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Category> CategoriesTable { get; set; }
        public virtual DbSet<Product> ProductsTable { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}