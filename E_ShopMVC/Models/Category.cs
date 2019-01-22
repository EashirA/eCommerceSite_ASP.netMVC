using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_ShopMVC.Models
{
    [Table("tblCategories")]
    public class Category
    {
        //public Category()
        //{
        //    Products = new List<Product>();
        //}
        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}