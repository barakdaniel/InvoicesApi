namespace Invoices.Model.Invoice
{
    public class InvoiceInsert
    {
        public string InvoiceId { get; set; }
        public DateTime Time { get; set; }
        public double Amount { get; set; }
    }
}
