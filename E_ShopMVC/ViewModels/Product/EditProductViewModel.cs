using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace E_ShopMVC.ViewModels.Product
{
    public class EditProductViewModel
    {

        [Required]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "This Value Required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Invalid")]
        public string ProductName { get; set; }
        [StringLength(500, MinimumLength = 4, ErrorMessage = "Invalid")]
        public string ProductDetail { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<SelectListItem> CategoryDropDownList { get; set; }
    }
}