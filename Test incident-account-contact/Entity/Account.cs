using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test_incident_account_contact.Entity
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Incident Incident { get; set; }
        public Guid? IncidentId { get; set; }
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
