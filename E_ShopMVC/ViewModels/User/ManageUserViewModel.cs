using System.Collections.Generic;
using System.Web.Mvc;

namespace E_ShopMVC.ViewModels.User
{
    public class ManageUserViewModel
    {
            public string UserId { get; set; }
            public string UserRoles { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public List<SelectListItem> UsersInSystem { get; set; }
            public string DropDown { get; set; }
    }
}