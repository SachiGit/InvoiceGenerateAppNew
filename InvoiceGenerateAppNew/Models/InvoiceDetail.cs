using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceGenerateAppNew.Models
{
    [Table("InvoiceDetail")]
    public class InvoiceDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceID { get; set; }       

        [StringLength(150)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Transaction Date")]
        [DataType(DataType.Date)]
        public DateOnly? TransDate { get; set; }

        [Display(Name = "Discount (in %)")]
        public decimal Discounts { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        [Range(1, 1000, ErrorMessage = "Please Enter a Value Between 1 and 1000")]
        public int Qty { get; set; }

        [Display(Name = "Amount (in Rs.)")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Balance Amount (in Rs.)")]
        public decimal BalanceAmount { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }

    }
}
