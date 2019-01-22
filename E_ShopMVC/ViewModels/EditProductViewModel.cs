using System.ComponentModel.DataAnnotations;

namespace E_ShopMVC.ViewModels
{
    public class EditProductViewModel
    {
        [Key]
        [Required]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "This Value Required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Invalid")]
        public string ProductName { get; set; }
        [StringLength(500, MinimumLength = 4, ErrorMessage = "Invalid")]
        public string ProductDetail { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
    }
}