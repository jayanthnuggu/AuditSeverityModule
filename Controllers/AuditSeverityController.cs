using AuditSeverityModule.Models;
using AuditSeverityModule.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AuditSeverityModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditSeverityController : ControllerBase
    {
        private readonly ISeverityProvider _severityProvider;
        public AuditSeverityController(ISeverityProvider severityProvider)
        {
            _severityProvider = severityProvider;
        }

        [HttpGet]
        public IActionResult ProjectExecutionStatus()
        {
            return Ok("SUCCESS");
        }



        [HttpPost]
        public IActionResult ProjectExecutionStatus([FromBody] AuditRequest req)
        {

            if (req == null)
                return BadRequest();

            if (req.Auditdetails.Type != "Internal" && req.Auditdetails.Type != "SOX")
                return BadRequest("Wrong Audit Type");

            try
            {
                AuditResponse response = _severityProvider.SeverityResponse(req);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}

