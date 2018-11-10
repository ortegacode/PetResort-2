using PetResort.Core.Contracts;
using PetResort.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace PetResort.Data.InMemory
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
        // <T> is the placeholder for our generic class always after the class declaration
    {
        ObjectCache cache = MemoryCache.Default;  // created an object cache
        List<T> items;  // internal list referencing our placeholder
        string className;  // variable className to store our object in cache

        public InMemoryRepository() // constructor
        {
            className = typeof(T).Name;  // gets the actual name of our class using reflection (typeof)

            items = cache[className] as List<T>; // initialize our internal items class
            if (items == null)  // if there is no items
            {
                items = new List<T>();  // start a new list
            }
        }
        public void Commit()
        {
            cache[className] = items;  //stores our items in memory
        }

        public void Insert(T t)
        {
            items.Add(t);
        }

        public void Update(T t)
        {
            T tToUpdate = items.Find(i => i.Id == t.Id);

            if (tToUpdate != null)
            {
                tToUpdate = t;
            }
            else
            {
                throw new Exception(className + " Not Found.");
            }
        }

            public T Find(string Id)
        {
            T t = items.Find(i=> i.Id == Id);
            if (t != null)
            {
                return t;
            }
            else
            {
                throw new Exception(className + " Not Found.");
            }
        }
        
       public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        public void Delete(string Id)
        {
            T tToDelete = items.Find(i => i.Id == Id);

            if (tToDelete != null)
            {
                items.Remove(tToDelete);
            }
            else
            {
                throw new Exception(className + " Not Found.");
            }
        }
    }
}
