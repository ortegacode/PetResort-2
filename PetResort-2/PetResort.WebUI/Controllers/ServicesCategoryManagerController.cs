using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetResort.Data.InMemory;
using PetResort.Core.Models;

namespace PetResort.WebUI.Controllers
{
    public class ServicesCategoryManagerController : Controller
    {
        ServicesCategoryRepository context;

        public ServicesCategoryManagerController()
        {
            context = new ServicesCategoryRepository();
        }

        // GET: PetManager
        public ActionResult Index()
        {
            List<ServicesCategory> serviceCategories = context.Collection().ToList();
            return View(serviceCategories);
        }

        public ActionResult Create()
        {
            ServicesCategory servicesCategory = new ServicesCategory();
            return View(servicesCategory);
        }

        [HttpPost]
        public ActionResult Create(ServicesCategory servicesCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(servicesCategory);
            }
            else
            {
                context.Insert(servicesCategory);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ServicesCategory servicesCategory = context.Find(Id);
            if (servicesCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(servicesCategory);
            }
        }

        [HttpPost]
        public ActionResult Edit(ServicesCategory servicesCategory, string Id)
        {
            ServicesCategory servicesCategoryToEdit = context.Find(Id);
            if (servicesCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(servicesCategory);
                }

                servicesCategoryToEdit.Category = servicesCategory.Category;
                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(string Id)
        {
            ServicesCategory servicesCategoryToDelete = context.Find(Id);
            if (servicesCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(servicesCategoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ServicesCategory servicesCategoryToDelete = context.Find(Id);
            if (servicesCategoryToDelete == null)
            {
                return HttpNotFound();
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