using AuditSeverityModule.Models;

namespace AuditSeverityModule.Providers
{
    public interface ISeverityProvider
    {
        public AuditResponse SeverityResponse(AuditRequest Req);
    }
}
