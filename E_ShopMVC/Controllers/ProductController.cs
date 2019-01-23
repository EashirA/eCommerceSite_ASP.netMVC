using E_ShopMVC.Data;
using E_ShopMVC.Models;
using E_ShopMVC.ViewModels.Product;
using System.Collections.Generic;
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
            var model = new ProductIndexViewModel.ProductListViewModel();
            using (var db = new EShopContext())
            {
                var c = db.ProductsTable.Find(id);
                model.ProductId = c.ProductId;
                model.ProductName = c.ProductName;
                model.ProductDetail = c.ProductDetail;
                model.Price = c.ProductPrice;
                model.CategoryName = c.Category.CategoryName;
                return View(model);
            }
        }



        [HttpGet]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult Edit(int? id)
        {
            using (var db = new EShopContext())
            {
                var product = db.ProductsTable.Find(id);
                var model = new EditProductViewModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDetail = product.ProductDetail,
                    ProductPrice = product.ProductPrice,
                    CategoryId = product.CategoryId
                };
                DropDownCategories(model);
                return View(model);
            }
        }

        public void DropDownCategories(EditProductViewModel model)
        {
            model.CategoryDropDownList = new List<SelectListItem>();
            using (var db = new EShopContext())
            {
                foreach (var c in db.CategoriesTable)
                {
                    model.CategoryDropDownList.Add(new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.CategoryName

                    });
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin,ProductManager")]
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
                product.CategoryId = model.CategoryId;

                db.SaveChanges();
                return RedirectToAction("Product", new { id = model.CategoryId });
            }
        }



        [HttpGet]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult Create(int id)
        {
            var model = new EditProductViewModel { CategoryId = id };
            using (var db = new EShopContext())
            {
                model.CategoryName = string.Join("", db.CategoriesTable.Where(x => x.CategoryId == id).Select(x => x.CategoryName));
                model.CategoryId = id;
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,ProductManager")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EditProductViewModel model)
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
                    ProductPrice = model.ProductPrice,
                    CategoryId = model.CategoryId,
                };
                db.ProductsTable.Add(product);
                db.SaveChanges();
            }
            return RedirectToAction("Product");
        }

        [HttpGet]
        [Authorize(Roles = "Admin,ProductManager")]
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
    }

}
