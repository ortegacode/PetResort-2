using PetResort_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace PetResort.Data.InMemory
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;  // created our object cache
        List<T> items;  // created our internal list of our placeholder T
        string className;

        public InMemoryRepository()  // constructor to initialize our Repo
        {
            className = typeof(T).Name;  //gets our actual className of the T placeholder
            items = cache[className] as List<T>; // initialized our internal items className
            if (items == null)
            {
                items = new List<T>();
            }
        }

        public void Commit()   //generic commit () that will store our items in memory
        {
            cache[className] = items;
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
                throw new Exception(className + " Not Found");
            }
        }

        public T Find(string Id)
        {
            T t = items.Find(i => i.Id == Id);
            if (t != null)
            {
                return t;
            }
            else
            {
                throw new Exception(className + " Not Found");

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
                throw new Exception(className + " Not Found");
            }
        }
    }

    public interface IRepository<T> where T : BaseEntity
    {
    }
}
