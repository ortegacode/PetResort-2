using PetResort.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetResort.Core.ViewModels
{
    public class CustomerManagerViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<ServicesCategory> ServicesCategories { get; set; }
    }
}
