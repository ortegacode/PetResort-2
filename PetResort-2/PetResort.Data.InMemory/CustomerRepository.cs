using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using PetResort.Core;
using PetResort.Core.Models;

namespace PetResort.Data.InMemory
{
    public class CustomerRepository 
    {
        ObjectCache cache = MemoryCache.Default; // created our Object Cache
        List<Customer> customers; //  a list of Customer called customers

        public CustomerRepository()
        {
            customers = cache["customers"] as List<Customer>; // looks in  the cache for a cache call customers and returns it as a list of customers

            if (customers == null)  // if null (does not find anything in cache)
            {
                customers = new List<Customer>(); // customers will create a new list of Customer
            }
        }

            public void Commit() // so when we add a customer to our repo we dont save it right away and explicitly tell it to persist them so when we r ready to save the customer we will store our list of customers to cache
        {
            cache["customers"] = customers;
        }
        
        public void Insert(Customer c)  
        {
            customers.Add(c); // add a customer to our Customer List
        }

        public void Update(Customer customer)
        {
            Customer customerToUpdate = customers.Find(c => c.Id == customer.Id); // looks into the db for the customer we want to update

            if (customerToUpdate != null)  // makes sure we received a customer
            {
                customerToUpdate = customer; // copies the info from the customer we sent in to that customer and updates the underlying list
            }
            else
            {
                throw new Exception("Customer not found");
            }                        
        }

        public Customer Find(string Id)
        {
            Customer customer= customers.Find(c => c.Id == Id);  // find the Id in the db
            if (customer != null)  // if found
            {
                return customer; // return it
            }
            else
            {
                throw new Exception("Customer not found");
            }
        }

        public IQueryable<Customer> Collection()  //  a Customer list that can be queried
        {
            return customers.AsQueryable();  //returns a customers list that can be Queried
        }

        public void Delete (string Id)
        {
            Customer customerToDelete = customers.Find(c => c.Id == Id); // looks into the db for the customer we want to delete

            if (customerToDelete != null)  // makes sure we received a customer
            {
                customers.Remove(customerToDelete); // copies the info from the customer we sent in to that customer and deletes the underlying list
            }
            else
            {
                throw new Exception("Customer not found");
            }
        }
    }
}
