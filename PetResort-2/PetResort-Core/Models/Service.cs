using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetResort.Core.Models
{
    public class Service : BaseEntity
    {
        //public string Id { get; set; }
        public string Grooming { get; set; }
        public string Boarding { get; set; }
        public string Party { get; set; }
        //public string SelectedService { get; set; }
        //public string Image { get; set; }

        //public Service()  // removed constructor because it is created in the base class
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //}
    }
}
