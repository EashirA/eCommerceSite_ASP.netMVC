using System.Collections.Generic;

namespace E_ShopMVC.ViewModels.Product
{
    public class ViewProductViewModel
    {
        public ViewProductViewModel()
        {
            LaptopCategory = new List<CategoryProductViewModel>();
        }
        public class CategoryProductViewModel
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductDetail { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
        }
        public List<CategoryProductViewModel> LaptopCategory { get; set; }
        public string CurrentSort { get; set; }
    }
}