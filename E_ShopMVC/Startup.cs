using E_ShopMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_ShopMVC.Startup))]
namespace E_ShopMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var user = new ApplicationUser
                {
                    UserName = "stefan.holmberg@nackademin.se",
                    Email = "stefan.holmberg@nackademin.se"
                };
                var userPassword = "Asp.netMVC";
                var chkUser = userManager.Create(user, userPassword);

                if (chkUser.Succeeded)
                    userManager.AddToRole(user.Id, "Admin");

            }
            if (!roleManager.RoleExists("ProductManager"))
            {
                var role = new IdentityRole { Name = "ProductManager" };
                roleManager.Create(role);

                var user = new ApplicationUser
                {
                    UserName = "arafat@gmail.com",
                    Email = "arafat@gmail.com"
                };
                var userPassword = "Asp.netMVC";
                var chkUser = userManager.Create(user, userPassword);

                if (chkUser.Succeeded)
                    userManager.AddToRole(user.Id, "ProductManager");

            }
        }
    }
}
