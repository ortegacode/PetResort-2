using PetResort_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace PetResort.Data.InMemory
{
    public class ServiceRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Service> services;

        public ServiceRepository()
        {
            services = cache["services"] as List<Service>;
            if (services == null)
            {
                services = new List<Service>();
            }
        }

        public void Commit()
        {
            cache["services"] = services;
        }

        public void Insert(Service s)
        {
            services.Add(s);
        }

        public void Update(Service service)
        {
            Service serviceToUpdate = services.Find(s => s.Id == service.Id);

            if (serviceToUpdate != null)
            {
                serviceToUpdate = service;
            }
            else
            {
                throw new Exception("Service not Found");
            }
        }

        public Service Find(string Id)
        {
            Service service = services.Find(s => s.Id == Id);
            if (services != null)
            {
                return service;
            }
            else
            {
                throw new Exception("Service not found");
            }
        }

        public IQueryable<Service> Collection()
        {
            return services.AsQueryable();
        }

        public void Delete(string Id)
        {
            Service serviceToDelete = services.Find(s => s.Id == Id);
            if (serviceToDelete != null)
            {
                services.Remove(serviceToDelete);
            }
            else
            {
                throw new Exception("Service not found");
            }
        }
    }
}