using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetResort.Data.InMemory;
using PetResort.Core.Models;
using PetResort.Core.Contracts;

namespace PetResort.WebUI.Controllers
{
    public class PetManagerController : Controller
    {

        IRepository<Pet> context;
        IRepository<Customer> clients;
        IRepository<Service> work;

        public PetManagerController(IRepository<Pet> petContext, IRepository<Customer> customerclients, IRepository<Service> workService)
        {
            context = petContext;
            clients = customerclients;
            work = workService;
        }

        // GET: PetManager
        public ActionResult Index()
        {
            List<Pet> pets = context.Collection().ToList();
            return View(pets);
        }

        public ActionResult Create()
        {
            Pet pet = new Pet();
            return View(pet);
        }

        [HttpPost]
        public ActionResult Create(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return View(pet);
            }
            else
            {
                context.Insert(pet);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Pet pet = context.Find(Id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(pet);
            }
        }

        [HttpPost]
        public ActionResult Edit(Pet pet, string Id)
        {
            Pet petToEdit = context.Find(Id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(pet);
                }

                petToEdit.PetName = pet.PetName;
                petToEdit.Notes = pet.Notes;
                petToEdit.PetPhoto = pet.PetPhoto;

                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(string Id)
        {
            Pet petToDelete = context.Find(Id);
            if (petToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(petToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Pet petToDelete = context.Find(Id);
            if (petToDelete == null)
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
