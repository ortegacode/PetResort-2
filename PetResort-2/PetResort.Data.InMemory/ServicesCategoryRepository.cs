using PetResort.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace PetResort.Data.InMemory
{
    public class ServicesCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ServicesCategory> servicesCategories;

        public ServicesCategoryRepository()
        {
            servicesCategories = cache["servicesCategories"] as List<ServicesCategory>;
            if (servicesCategories == null)
            {
                servicesCategories = new List<ServicesCategory>();
            }

        }

        public void Commit()
        {
            cache["servicesCategories"] = servicesCategories;
        }

        public void Insert(ServicesCategory s)
        {
            servicesCategories.Add(s);
        }

        public void Update(ServicesCategory servicesCategory)
        {
            ServicesCategory servicesCategoryToUpdate = servicesCategories.Find(s => s.Id == servicesCategory.Id);

            if (servicesCategoryToUpdate != null)
            {
                servicesCategoryToUpdate = servicesCategory;
            }
            else
            {
                throw new Exception("Services not Found");
            }
        }

        public ServicesCategory Find(string Id)
        {
            ServicesCategory servicesCategory = servicesCategories.Find(s => s.Id == Id);
            if (servicesCategory != null)
            {
                return servicesCategory;
            }
            else
            {
                throw new Exception("Services not found");
            }
        }

        public IQueryable<ServicesCategory> Collection()
        {
            return servicesCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ServicesCategory servicesCategoryToDelete = servicesCategories.Find(s => s.Id == Id);
            if (servicesCategoryToDelete != null)
            {
                servicesCategories.Remove(servicesCategoryToDelete);
            }
            else
            {
                throw new Exception("Services not found");
            }
        }

    }
}

