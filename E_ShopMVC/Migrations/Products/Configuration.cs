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
                    CategoryDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt" +
                                          " ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco " +
                                          "laboris nisi ut aliquip ex ea commodo consequat."
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Professional",
                    CategoryDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt" +
                                          " ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco " +
                                          "laboris nisi ut aliquip ex ea commodo consequat."
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Gaming",
                    CategoryDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt" +
                                          " ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco " +
                                          "laboris nisi ut aliquip ex ea commodo consequat."
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Apple",
                    CategoryDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt" +
                                          " ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco " +
                                          "laboris nisi ut aliquip ex ea commodo consequat."
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "UltraBooks",
                    CategoryDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt" +
                                          " ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco " +
                                          "laboris nisi ut aliquip ex ea commodo consequat."
                }
                );
            context.SaveChanges();

            context.ProductsTable.AddOrUpdate(x => x.ProductId,
                new Models.Product
                {
                    ProductId = 1,
                    ProductDetail = "Core i5 8GB 256GB 15.6",
                    ProductName = "Lenovo V130  ",
                    ProductPrice = 5999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 1),

                },
                new Models.Product
                {
                    ProductId = 2,
                    ProductDetail = "Core i3 8GB 256GB 15.6 ",
                    ProductName = "HP 250 G6  ",
                    ProductPrice = 4999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 1),

                },
                new Models.Product
                {
                    ProductId = 3,
                    ProductDetail = "Core i7 16GB 512GB 14",
                    ProductName = "Lenovo ThinkPad T480s  ",
                    ProductPrice = 16999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 2),

                },
                new Models.Product
                {
                    ProductId = 4,
                    ProductDetail = "Core i7 16GB 512GB 14",
                    ProductName = "Lenovo ThinkPad X1 Yoga  ",
                    ProductPrice = 24999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 2),

                },
                new Models.Product
                {
                    ProductId = 5,
                    ProductDetail = "Core i7 16GB 512GB SSD 15.6 144Hz GTX 1060",
                    ProductName = "Razer Blade  ",
                    ProductPrice = 21999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 3),

                }, new Models.Product
                {
                    ProductId = 6,
                    ProductDetail = "Core i7 16GB 256GB SSD 17.3 120Hz GTX 1080 ",
                    ProductName = "MSI GT75 Titan  ",
                    ProductPrice = 31490,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 3),

                },
                new Models.Product
                {
                    ProductId = 7,
                    ProductDetail = "Core i5 8GB 512GB 13.3",
                    ProductName = "Apple MacBook Pro med Touch Bar - Silver  ",
                    ProductPrice = 19190,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 4),

                },
                new Models.Product
                {
                    ProductId = 8,
                    ProductDetail = "Core i7 16GB 256GB 15.4 ",
                    ProductName = "Apple MacBook Pro med Touch Bar - Silver   ",
                    ProductPrice = 16999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 4),

                },
                new Models.Product
                {
                    ProductId = 9,
                    ProductDetail = "Core i7 8GB 256GB 13.3",
                    ProductName = "Lenovo IdeaPad 720s  ",
                    ProductPrice = 9999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 5),

                },
                new Models.Product
                {
                    ProductId = 10,
                    ProductDetail = "Core i5 8GB 512GB 13.3 ",
                    ProductName = "ASUS ZenBook 13 UX331UAL ",
                    ProductPrice = 11999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 5)

                }

                );
            context.SaveChanges();
        }
    }
}
