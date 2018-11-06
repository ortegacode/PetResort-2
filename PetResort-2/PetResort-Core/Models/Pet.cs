using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PetResort.Core.Models
{
    public class Pet
    {
        public string Id { get; set; }
        [Required]
        public string AnimalType { get; set; }
        [Required]
        public string PetName { get; set; }
        [Required]
        public string Notes { get; set; }     
        public string PetImage { get; set; }

        public Pet()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
