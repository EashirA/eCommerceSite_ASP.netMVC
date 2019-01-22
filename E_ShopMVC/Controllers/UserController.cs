using System.Web.Mvc;

namespace E_ShopMVC.Controllers
{
    //public class UserController : Controller
    //{
        // GET: User
        //[Authorize]
//        public ActionResult Index()
//        {

//            var model = new UserViewModel();
//            var role = new IdentityDbContext();

//            using (var db = new ApplicationDbContext())
//            {
//                model.Users.AddRange(db.Users.ToList().Select(u => new UserViewModel.UserListViewModel
//                {
//                    UserId = u.Id,
//                    Email = u.Email,
//                    UserName = u.UserName,
//                    UserRoles = u.Roles
//                }));
//            }






























//            //var model = new ProductIndexViewModel();
//            //using (var db = new EShopContext())
//            //{
//            //    model.Products.AddRange(db.ProductsTable.ToList().Select(p => new ProductIndexViewModel.ProductListViewModel
//            //    {
//            //        ProductId = p.ProductId,
//            //        ProductName = p.ProductName,
//            //        ProductDetail = p.ProductDetail,
//            //        Price = p.ProductPrice,
//            //        CategoryName = p.Category.CategoryName,
//            //        CategoryId = p.CategoryId

//            //    }));
//            //}

//            //model = Sort(model, sort);
//            //return View(model);

//            //using (var db = new ApplicationDbContext())
//            //{
//            //    var model = (from user in db.Users
//            //        select new
//            //        {
//            //            UserId = user.Id,
//            //            Username = user.UserName,
//            //            Email = user.Email,
//            //            RoleNames = (from userRole in user.Roles
//            //                join role in db.Roles on userRole.RoleId
//            //                    equals role.Id
//            //                select role.Name).ToList()
//            //        }).ToList().Select(p => new UserViewModel()
//            //    {
//            //            UserId = p.UserId,
//            //            UserName = p.Username,
//            //            Email = p.Email,
//            //            UserRoles = string.Join(",", p.RoleNames)
//            //        });
//           return View(model);
//            }
//        }
//    }
}