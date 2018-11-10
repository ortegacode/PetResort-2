using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using PetResort.Core.Models;


namespace PetResort.Data.InMemory
{
    public class PetRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Pet> pets;

        public PetRepository()
        {
            pets = cache["pets"] as List<Pet>;
            if (pets == null)
            {
                pets = new List<Pet>();
            }

        }

        public void Commit()
        {
            cache["pets"] = pets;
        }

        public void Insert(Pet p)
        {
            pets.Add(p);
        }

        public void Update(Pet pet)
        {
            Pet petToUpdate = pets.Find(p => p.Id == pet.Id);

            if (petToUpdate != null)
            {
                petToUpdate = pet;
            }
            else
            {
                throw new Exception("Pet not Found");
            }
        }

        public Pet Find(string Id)
        {
            Pet pet = pets.Find(p => p.Id == Id);
            if (pet != null)
            {
                return pet;
            }
            else
            {
                throw new Exception("Pet not found");
            }
        }

        public IQueryable<Pet> Collection()
        {
            return pets.AsQueryable();
        }

        public void Delete(string Id)
        {
            Pet petToDelete = pets.Find(p => p.Id == Id);
            if (petToDelete != null)
            {
                pets.Remove(petToDelete);
            }
            else
            {
                throw new Exception("Pet not found");
            }
        }

    }
}