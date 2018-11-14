using PetResort.Core.Contracts;
using PetResort.Core.Models;
using PetResort.Data.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetResort.WebUI.Controllers
{
    public class ServiceManagerController : Controller

    {
        IRepository<Service> work;

        public ServiceManagerController(IRepository<Pet> petContext, IRepository<Customer> customerClients, IRepository<Service> work)
        {
            
            this.work = work;
        }

       
        // GET: ServiceManager
        public ActionResult Index()
        {
            List<Service> services = work.Collection().ToList();
            return View(services);
        }

        public ActionResult Create()
        {
            Service service = new Service();
            return View(service);
        }

        [HttpPost]
        public ActionResult Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            else
            {
                work.Insert(service);
                work.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Service service = work.Find(Id);
            if (service == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(service);
            }
        }

        [HttpPost]
        public ActionResult Edit(Service service, string Id)
        {
            Service serviceToEdit = work.Find(Id);
            if (service == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(service);
                }

                serviceToEdit.Grooming = service.Grooming;
                serviceToEdit.Boarding = service.Boarding;
                serviceToEdit.Party = service.Party;

                work.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(string Id)
        {
            Service serviceToDelete = work.Find(Id);
            if (serviceToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(serviceToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Service serviceToDelete = work.Find(Id);
            if (serviceToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                work.Delete(Id);
                work.Commit();

                return RedirectToAction("Index");
            }
        }
    }
}