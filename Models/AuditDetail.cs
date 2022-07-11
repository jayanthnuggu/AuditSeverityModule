namespace AuditSeverityModule.Models
{
    public class AuditDetail
    {
        public string Type { get; set; }
        public string Date { get; set; }
        public Questions questions { get; set; }
    }
}
