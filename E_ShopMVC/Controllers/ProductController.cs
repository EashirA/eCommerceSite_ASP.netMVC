using E_ShopMVC.Data;
using E_ShopMVC.Models;
using E_ShopMVC.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace E_ShopMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product


        public ActionResult Product(string sort)
        {
            var model = new ProductIndexViewModel();
            using (var db = new EShopContext())
            {
                model.Products.AddRange(db.ProductsTable.ToList().Select(p => new ProductIndexViewModel.ProductListViewModel
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    ProductDetail = p.ProductDetail,
                    Price = p.ProductPrice,
                    CategoryName = p.Category.CategoryName,
                    CategoryId = p.CategoryId

                }));
            }

            model = Sort(model, sort);
            return View(model);
        }


        public ActionResult Search(string searchString, string sort)
        {
            var model = new ProductIndexViewModel();
            using (var db = new EShopContext())
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    var products = db.ProductsTable.Where(p => p.ProductName.Contains(searchString));
                    foreach (var p in products)
                    {
                        var pModel = new ProductIndexViewModel.ProductListViewModel
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            ProductDetail = p.ProductDetail,
                            Price = p.ProductPrice,
                            CategoryName = p.Category.CategoryName

                        };
                        model.Products.Add(pModel);
                    }
                    model = Sort(model, sort);
                }
                return View(model);
            }
        }
        
        public ActionResult View(int id, string sort)
        {
            var model = new ProductIndexViewModel();

            using (var db = new EShopContext())
            {
                model.CategoryName = string.Join("", db.CategoriesTable.Where(c => c.CategoryId == id).Select(c => c.CategoryName));
                model.CategoryId = id;
                model.Products.AddRange(db.ProductsTable
                    .Select(p => new ProductIndexViewModel.ProductListViewModel
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        ProductDetail = p.ProductDetail,
                        Price = p.ProductPrice,
                        CategoryId = p.CategoryId
                    }).Where(c => c.CategoryId == id));

                model = Sort(model, sort);

                return View(model);
            }
        }

        public ProductIndexViewModel Sort(ProductIndexViewModel model, string sort)
        {
            if (sort == "ProductNameAsc")
                model.Products = model.Products.OrderBy(r => r.ProductName).ToList();
            else if (sort == "ProductNameDesc")
                model.Products = model.Products.OrderByDescending(r => r.ProductName).ToList();


            if (sort == "ProductPriceAsc")
                model.Products = model.Products.OrderBy(r => r.Price).ToList();
            else if (sort == "ProductPriceDesc")
                model.Products = model.Products.OrderByDescending(r => r.Price).ToList();
            model.CurrentSort = sort;
            return model;
        }

        public ActionResult ViewAProduct(int? id)
        {
            if (id == null) return RedirectToAction("Product");

            using (var db = new EShopContext())
            {
                var c = db.ProductsTable.FirstOrDefault(p => p.CategoryId == id);
                var model = new ViewAProductViewModel
                {
                    ProductId = c.ProductId, // Having Problem here with last products ID .. showing as null
                    ProductName = c.ProductName,
                    ProductDetail = c.ProductDetail,
                    Price = c.ProductPrice,
                    Category = c.Category.CategoryName
                };
                return View(model);
            }
        }



        [HttpGet]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Edit");
            using (var db = new EShopContext())
            {
                var product = db.ProductsTable.FirstOrDefault(p => p.ProductId == id);
                var model = new EditProductViewModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDetail = product.ProductDetail,
                    ProductPrice = product.ProductPrice
                };
                return View(model);
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new EShopContext())
            {
                var product = db.ProductsTable.FirstOrDefault(r => r.ProductId == model.ProductId);
                product.ProductId = model.ProductId;
                product.ProductName = model.ProductName;
                product.ProductDetail = model.ProductDetail;
                product.ProductPrice = model.ProductPrice;

                db.SaveChanges();
            }
            return RedirectToAction("Product");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var model = new CreateProductViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new EShopContext())
            {
                var product = new Product
                {
                    ProductId = model.ProductId,
                    ProductName = model.ProductName,
                    ProductDetail = model.ProductDetail,
                    ProductPrice = model.ProductPrice
                };
                db.ProductsTable.Add(product);
                db.SaveChanges();
            }
            return RedirectToAction("Product");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            using (var db = new EShopContext())
            {
                var product = db.ProductsTable.Find(id);
                if (product != null)
                    db.ProductsTable.Remove(product);

                db.SaveChanges();
            }
            return RedirectToAction("Product");
        }



        // This can be use as sorted category products
        //var model = new ProductIndexViewModel();
        //using (var db = new EShopContext())
        //{
        //    model.CategoryName = string.Join(" ", db.CategoriesTable.Where(p => p.CategoryId == id).Select(p => p.CategoryName));

        //    model.Products.AddRange(db.ProductsTable.Select(p => new ProductIndexViewModel.ProductListViewModel
        //    {
        //        ProductId = p.ProductId,
        //        ProductName = p.ProductName,
        //        ProductDetail = p.ProductDetail,
        //        Price = p.ProductPrice,
        //        CategoryId = p.CategoryId

        //    }).Where(p => p.CategoryId == id));
        //}
    }

}
