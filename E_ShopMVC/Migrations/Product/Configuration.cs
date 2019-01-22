using E_ShopMVC.Data;
using E_ShopMVC.Models;
using System.Data.Entity.Migrations;
using System.Linq;

namespace E_ShopMVC.Migrations.Product
{
    internal sealed class Configuration : DbMigrationsConfiguration<EShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Products";
        }

        protected override void Seed(EShopContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.CategoriesTable.AddOrUpdate(c => c.CategoryId,
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Standard",
                    CategoryDescription = "Som namnet antyder ...."
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Professional",
                    CategoryDescription = "Här hittar du våra bärbara ..."
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Gaming",
                    CategoryDescription = "Dessa datorer är vanligtvis kraftfulla..."
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Apple",
                    CategoryDescription = "Apple..."
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "UltraBooks",
                    CategoryDescription = "Ultrabooks är tunna och lätta bärbara datorer ..."
                }
                );
            context.SaveChanges();

            context.ProductsTable.AddOrUpdate(x => x.ProductId,
                new Models.Product
                {
                    ProductId = 1,
                    ProductDetail = "Blah blah blah",
                    ProductName = "Asus 75Xzr",
                    ProductPrice = 4999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 1),
                    //CategoryName = "Standard"

                },
                new Models.Product
                {
                    ProductId = 2,
                    ProductDetail = "Blah blah blah",
                    ProductName = "HP 75Xzr",
                    ProductPrice = 8999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 2),
                    //CategoryName = "Professional"

                },
                new Models.Product
                {
                    ProductId = 3,
                    ProductDetail = "Blah blah blah",
                    ProductName = "AlienWare 75Xzr",
                    ProductPrice = 17999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 3),
                    //CategoryName = "Gaming"

                },
                new Models.Product
                {
                    ProductId = 4,
                    ProductDetail = "Blah blah blah",
                    ProductName = "Apple Macbook Pro",
                    ProductPrice = 12999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 4),
                    //CategoryName = "Apple"

                },
                new Models.Product
                {
                    ProductId = 5,
                    ProductDetail = "Blah blah blah",
                    ProductName = "Lenovo IdeaPad",
                    ProductPrice = 9999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 5),
                    //CategoryName = "UltraBooks"

                },
                new Models.Product
                {
                    ProductId = 6,
                    ProductDetail = "Blah blah blah",
                    ProductName = "Apple Air Pro",
                    ProductPrice = 11999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 4),
                    //CategoryName = "Apple"

                }

                );
            context.SaveChanges();
        }
    }
}
