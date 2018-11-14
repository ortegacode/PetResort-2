using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetResort_Core.Models
{

    public class Pet : BaseEntity
    {
        //public string Id { get; set; }
        [Required]
        public string AnimalType { get; set; }
        [Required]
        public string PetName { get; set; }
        [Required]
        public string Notes { get; set; }
        public string PetPhoto { get; set; }

        //public Pet()
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //}
    }
}
