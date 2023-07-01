namespace Invoices.Model.ExceptionLog
{
    public class ExceptionLog
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime Time { get; set; }
        public string ExceptionContent { get; set; }
    }
}
