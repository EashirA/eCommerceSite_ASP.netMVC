using E_ShopMVC.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
using E_ShopMVC.Data;
using E_ShopMVC.Models;
using E_ShopMVC.ViewModels.Category;

namespace E_ShopMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        public ActionResult Index()
        {
            var model = new CategoryIndexViewModel();
            using (var db = new EShopContext())
            {
                model.Categories.AddRange(db.CategoriesTable.ToList().Select(c => new CategoryIndexViewModel.CategoryListViewModel
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    CategoryDescription = c.CategoryDescription
                }));
            }
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            using (var db = new EShopContext())
            {

                var category = db.CategoriesTable.FirstOrDefault(p => p.CategoryId == id);

                var model = new EditCategoryViewModel

                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.CategoryDescription

                };
                return View(model);
            }

        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new EShopContext())
            {
                var category = db.CategoriesTable.FirstOrDefault(r => r.CategoryId == model.CategoryId);
                category.CategoryId = model.CategoryId;
                category.CategoryName = model.CategoryName;
                category.CategoryDescription = model.Description;

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }





        
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var model = new CreateCategoryViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new EShopContext())
            {
                var category = new Category
                {
                    CategoryName = model.CategoryName,
                    CategoryDescription = model.Description
                };
                db.CategoriesTable.Add(category);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }


        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            using (var db = new EShopContext())
            {
                var category = db.CategoriesTable.Find(id);
                if (category != null)
                    db.CategoriesTable.Remove(category);

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}