namespace InvoiceGenerateAppNew.Models.ViewModels
{
    public class InvoiceViewModel
    {
        public IEnumerable<InvoiceDetail> InvoiceDetailsList { get; set; }       

        public InvoiceDetail InvoiceDetail { get; set; }        
    }
}
