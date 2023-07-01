namespace Invoices.Model.Invoice
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceId { get; set; }
        public DateTime Time { get; set; }
        public string StatusName { get; set; }
        public double Amount { get; set; }
    }
}
