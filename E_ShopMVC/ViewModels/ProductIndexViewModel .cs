using System.Collections.Generic;

namespace E_ShopMVC.ViewModels
{
    public class ProductIndexViewModel
    {

        public ProductIndexViewModel()
        {
            Products = new List<ProductListViewModel>();
        }

        public class ProductListViewModel
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductDetail { get; set; }
            public decimal Price { get; set; }
            //public string CategoryName { get; set; }
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }

        }

        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public List<ProductListViewModel> Products { get; set; }
        public string CurrentSort { get; set; }
        public string Search { get; set; }

    }
}