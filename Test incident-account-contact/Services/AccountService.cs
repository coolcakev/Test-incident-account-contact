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
    public interface IAccountService
    {
        bool Create(CreateAccountModel model);
        IEnumerable<Account> GetAccounts();
    }
    public class AccountService: IAccountService
    {
        private readonly ApplicationContext _applicationContext;

        public AccountService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public bool Create(CreateAccountModel model)
        {
            var contact = _applicationContext.Contacts.SingleOrDefault(contactLink => contactLink.Email == model.ContactEmail);
            if (contact == null)
                return false;

            var account = _applicationContext.Account.SingleOrDefault(account=> account.Name==model.Name);
            if (account!=null)
            {
                account.Contacts.Add(contact);
                _applicationContext.SaveChanges();
                return true;
            }
             account = new Account();
            account.Name = model.Name;
            account.Contacts.Add(contact);

            _applicationContext.Add(account);
            _applicationContext.SaveChanges();
            return true;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return _applicationContext.Account.Include(x => x.Contacts).Include(x => x.Incident);
        }
    }
}
