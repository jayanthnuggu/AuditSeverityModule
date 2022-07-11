namespace AuditSeverityModule.Models
{
    public class AuditRequest
    {
        public string ProjectName { get; set; }
        public string ProjectManagerName { get; set; }
        public string ApplicationOwnerName { get; set; }
        public AuditDetail Auditdetails { get; set; }
    }
}
