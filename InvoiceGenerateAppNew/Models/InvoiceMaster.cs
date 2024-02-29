using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceGenerateAppNew.Models
{
    public class InvoiceMaster
    {
        [Key]
        public int InvoiceMasterId { get; set; }       
        public DateTime TransactionDate { get; set; }
        public List<InvoiceDetail> Items { get; set; }
        public decimal Total { get; set; }

        public int InvoiceID { get; set; }
        [ForeignKey("InvoiceID")]
        [ValidateNever]
        public InvoiceDetail InvoiceDetail { get; set; }

    }
}
