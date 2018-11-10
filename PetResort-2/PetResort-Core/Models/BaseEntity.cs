using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetResort.Core.Models
{
    public abstract class BaseEntity  // (abstract class) can never create an instance of BaseEntity on its own cn only create a class that implements it
    {
        public string Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();  // gives our Id a guid
            this.DateCreated = DateTime.Now;  // gives DateCreated the time and date

        }
    }
}
