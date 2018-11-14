using PetResort.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetResort.Data.Sql
{
    public class DataContext :DbContext
    {
        public DataContext()  // constructor so we can capture and pass in the connection string
            : base("DefaultConnection")  // makes our DbContext class look in our Web.config file for (DefaultConnection)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Service> Service { get; set; }
    }
}
