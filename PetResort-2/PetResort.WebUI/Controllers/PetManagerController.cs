using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetResort.Data.InMemory;
using PetResort.Core.Models;
using PetResort.Core.Contracts;
using System.IO;

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
        public ActionResult Create(Pet pet, HttpPostedFileBase file)  //added the http"" file for the pic
        {
            if (!ModelState.IsValid)
            {
                return View(pet);
            }
            else
            {
                if (file!= null)
                {
                    pet.PetPhoto = pet.Id + Path.GetExtension(file.FileName);  // saves it using the petId instead of the uploaded filename because it will always have a unique filename ( user cant upload images with the same filename ) + Path(using.IO) allows us to get the file extension, gives us the full filename ( pet.id and extension name from file)

                    file.SaveAs(Server.MapPath("//Content//PetPhotos//") + pet.PetPhoto);
                }

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
        public ActionResult Edit(Pet pet, string Id, HttpPostedFileBase file)
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

                if (file != null)
                {
                    petToEdit.PetPhoto = pet.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//PetPhotos//") + petToEdit.PetPhoto);
                }

                petToEdit.PetName = pet.PetName;
                petToEdit.Notes = pet.Notes;
                //petToEdit.PetPhoto = pet.PetPhoto;  //removed ( done above)

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
