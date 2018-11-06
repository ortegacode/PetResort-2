using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetResort.Data.InMemory;
using PetResort.Core.Models;

namespace PetResort.WebUI.Controllers
{
    public class PetManagerController : Controller
    {

        PetRepository context;

        public PetManagerController()
        {
            context = new PetRepository();
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
                petToEdit.PetImage = pet.PetImage;

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

