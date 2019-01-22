using System.Collections.Generic;

namespace E_ShopMVC.ViewModels
{
    public class CategoryIndexViewModel
    {
        //public string SearchCategoryName { get; set; }

        public CategoryIndexViewModel()
        {
            Categories = new List<CategoryListViewModel>();
        }

        public class CategoryListViewModel
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public string CategoryDescription { get; set; }
        }
        public List<CategoryListViewModel> Categories { get; set; }
        // ID for product needed
        public string CurrentSort { get; set; }

    }
}