using AuditSeverityModule.Models;
using System.Collections.Generic;

namespace AuditSeverityModule.Repository
{
    public interface ISeverityRepo
    {
        public List<AuditBenchmark> Response();
    }
}
