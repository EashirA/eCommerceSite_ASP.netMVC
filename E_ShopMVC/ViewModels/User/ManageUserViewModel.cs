using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace E_ShopMVC.ViewModels.User
{
    public class ManageUserViewModel
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "The Name field is required.")]
        public string UserRoles { get; set; }
        [Required(ErrorMessage = "The Name field is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Name field is required.")]
        public string UserName { get; set; }
        public List<SelectListItem> UsersInSystem { get; set; }
        public string DropDown { get; set; }
    }
}