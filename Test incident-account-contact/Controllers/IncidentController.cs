using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_incident_account_contact.Entity;
using Test_incident_account_contact.Model;
using Test_incident_account_contact.Services;

namespace Test_incident_account_contact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _IncidentService;

        public IncidentController(IIncidentService incidentService)
        {
            _IncidentService = incidentService;
        }

        [HttpGet("GetIncidents")]
        public IEnumerable<Incident> GetIncidents()
        {
            return _IncidentService.GetIncidences();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateIncidentModel model)
        {
         var isCreateValid =   _IncidentService.Create(model);
            if (!isCreateValid)
                return NotFound();
            return Ok();
        }
    }
}
