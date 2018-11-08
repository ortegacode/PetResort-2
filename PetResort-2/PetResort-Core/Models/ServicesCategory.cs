using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetResort.Core.Models
{
    public class ServicesCategory
    {
        public string Id { get; set; }
        public string Category { get; set; }

        public ServicesCategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
