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
    public interface IContactService
    {
        bool Create(CreateContactModel model);
        IEnumerable<Contact> GetContacts();
    }
    public class ContactService: IContactService
    {
        private readonly ApplicationContext _applicationContext;

        public ContactService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public bool Create(CreateContactModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Email))
                return false;
            
            var contact = _applicationContext.Contacts.SingleOrDefault(contact => contact.Email == model.Email);
            if (contact != null)
            {
                contact.Email = model.Email;
                contact.Firstname = model.FirstName;
                contact.Lastname = model.LastName;

                _applicationContext.Update(contact);
                _applicationContext.SaveChanges();

                return true ;
            }

            contact = new Contact();

            contact.Email = model.Email;
            contact.Firstname = model.FirstName;
            contact.Lastname = model.LastName;

            _applicationContext.Add(contact);
            _applicationContext.SaveChanges();

            return true ;
        }
        public IEnumerable<Contact> GetContacts()
        {
            return _applicationContext.Contacts.Include(x => x.Account.Contacts).Include(x=>x.Account.Incident);
        }
    }
}
