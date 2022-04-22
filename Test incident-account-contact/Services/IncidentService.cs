using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_incident_account_contact.Base;
using Test_incident_account_contact.Entity;
using Test_incident_account_contact.Model;

namespace Test_incident_account_contact.Services
{
    public interface IIncidentService
    {
        bool Create(CreateIncidentModel model);
        IEnumerable<Incident> GetIncidences();
    }
    public class IncidentService : IIncidentService
    {
        private readonly ApplicationContext _applicationContext;

        public IncidentService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public bool Create(CreateIncidentModel model)
        {
            var account = _applicationContext.Account.SingleOrDefault(account => account.Name == model.AccountName);
            if (account == null)
                return false;

            var incident = _applicationContext.Incidents.SingleOrDefault(account => account.Name.ToString() == model.IncidentName);
            if (incident != null)
            {
                incident.Accounts.Add(account);
                _applicationContext.SaveChanges();
                return true;
            }

             incident = new Incident();
            incident.Description = model.Description;
            incident.Accounts.Add(account);

            _applicationContext.Add(incident);
            _applicationContext.SaveChanges();
            return true;
        }
        public IEnumerable<Incident> GetIncidences()
        {
            return _applicationContext.Incidents.Include(x=>x.Accounts).ThenInclude(x=>x.Contacts);
        }
    }
}
