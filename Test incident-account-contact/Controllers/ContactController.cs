using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_incident_account_contact.Entity;
using Test_incident_account_contact.Model;
using Test_incident_account_contact.Services;

namespace Test_incident_contact_contact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService incidentService)
        {
            _contactService = incidentService;
        }
        [HttpGet("GetContacts")]
        public IEnumerable<Contact> GetContacts()
        {
            var temp = _contactService.GetContacts();
            return temp;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateContactModel model)
        {
           var isCreateValid= _contactService.Create(model);

            if (!isCreateValid)
                return NotFound();
            return Ok();
        }
    }
}
