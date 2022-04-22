using Microsoft.EntityFrameworkCore;
using Test_incident_account_contact.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_incident_account_contact.Base
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        public DbSet<Incident>  Incidents{ get; set; }
        public DbSet<Contact>  Contacts{ get; set; }
        public DbSet<Account> Account { get; set; }

    }
}
