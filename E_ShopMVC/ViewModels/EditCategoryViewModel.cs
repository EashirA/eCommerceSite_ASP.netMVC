using System.ComponentModel.DataAnnotations;

namespace E_ShopMVC.ViewModels
{
    public class EditCategoryViewModel
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "This Value Required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Invalid")]
        public string CategoryName { get; set; }

        [StringLength(500, MinimumLength = 2, ErrorMessage = "Invalid")]
        public string Description { get; set; }
    }
}