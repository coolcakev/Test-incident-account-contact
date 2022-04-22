using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test_incident_account_contact.Entity
{
    public class Incident
    {
        [Key]
        public Guid Name { get; set; }
        public string Description { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
