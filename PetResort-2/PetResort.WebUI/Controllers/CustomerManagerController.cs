using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetResort.Core.Models;
using PetResort.Data.InMemory;

namespace PetResort.WebUI.Controllers
{
    public class CustomerManagerController : Controller
    {
        CustomerRepository context;  // created an instance(context) of our CustomerRepo

        public  CustomerManagerController () // constructor 
        {
            context = new CustomerRepository(); // initiallizes that repo
        }

        // GET: CustomerManager
        public ActionResult Index()
        {
            List<Customer> customers = context.Collection().ToList(); // list of customers from our collection and converts that to list
            return View(customers);  // sends customers to the view
        }

        public ActionResult Create()  // this view is to display the page in order to fill it out customer details
        {
            Customer customer = new Customer();
            return View(customer);
        }

        [HttpPost]
        public ActionResult Create(Customer customer) // to have customer details posted into db
        {
            if (!ModelState.IsValid) // checks to make sure any validation we set in is correct
            {
                return View(customer); // returns u back to page with the validation error messages
            }
            else
            {
                context.Insert(customer); // insert the customer into the collection(context)
                context.Commit();   // save (commit) changes to collection

                return RedirectToAction("Index"); // returns you back to the index page
            }
        }

        public ActionResult Edit(string Id)
        {
            Customer customer = context.Find(Id);  // will try to load the customer using the find() by Id
            if (customer == null)
            {
                return HttpNotFound();  // if no customer found
            }
            else
            {
                return View(customer);
            }
        }
            
            [HttpPost]
            public ActionResult Edit(Customer customer, string Id) // the updated customer along with the Id
        {
            Customer customerToEdit = context.Find(Id);  // loaded the customer we are editing from the db using the Id
            if (customer == null)
            {
                return HttpNotFound();  // if no customer found
            }
            else
            {
                if (!ModelState.IsValid) // checks validation
                {
                    return View(customer);
                }

                // Manually update the info we send thru

                customerToEdit.FirstName = customer.FirstName;
                customerToEdit.LastName = customer.LastName;
                customerToEdit.Email = customer.Email;
                customerToEdit.Address = customer.Address;
                customerToEdit.City = customer.City;
                customerToEdit.State = customer.State;
                customerToEdit.Zipcode = customer.Zipcode;
                customerToEdit.PhoneNumber = customer.PhoneNumber;

                context.Commit(); // save changes

                return RedirectToAction("Index");  // send them back to the index page
            }
        }

        public ActionResult Delete(string Id)
        {
            Customer customerToDelete = context.Find(Id);  // will load the customer using the find() by Id
            if (customerToDelete == null)
            {
                return HttpNotFound();  // if no customer found
            }
            else
            {
                return View(customerToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Customer customerToDelete = context.Find(Id);  // will load the customer using the find() by Id
            if (customerToDelete == null)
            {
                return HttpNotFound();  // if no customer found
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        
    }
}