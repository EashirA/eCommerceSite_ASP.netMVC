using System.Collections.Generic;

namespace E_ShopMVC.ViewModels.User
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Users = new List<UserListViewModel>();
        }

        public class UserListViewModel
        {
            public string UserId { get; set; }
            public string UserRoles { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string UserName { get; set; }

        }
        public List<UserListViewModel> Users { get; set; }
    }

   
}