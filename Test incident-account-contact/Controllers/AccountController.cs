using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService incidentService)
        {
            _accountService = incidentService;
        }
        [HttpGet("GetAccounts")]
        public IEnumerable<Account> GetAccounts()
        {
            var temp = _accountService.GetAccounts();
            return temp;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateAccountModel model)
        {
           var isCreateValid= _accountService.Create(model);
            if (!isCreateValid)
                return NotFound();
            
            return Ok();
        }
    }
}
