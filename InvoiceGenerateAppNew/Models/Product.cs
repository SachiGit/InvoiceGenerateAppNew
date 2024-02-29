using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InvoiceGenerateAppNew.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]

        [Required]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Product Price")]
        public decimal ProductPrice { get; set; }

        public int StoreQuantity { get; set; }

        //[Range(1, 1000, ErrorMessage = "Please Enter a Value Between 1 and 1000")]
        //public int Count { get; set; }
    }
}
