using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_ShopMVC.Models
{
    [Table("tblProducts")]
    public class Product
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDetail { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }

        public virtual Category Category { get; set; }
        public int CategoryId { get; internal set; }

        // public byte[] LaptopImage { get; set; }
        // public string PhotoPath { get; set; }

    }
}