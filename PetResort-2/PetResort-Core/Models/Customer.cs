﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetResort.Core.Models
{
    public class Customer
    {
        public string Id { get; set; }
        [StringLength(20)]
        [DisplayName("Customer First Name")]
        public string FirstName { get; set; }
        [StringLength(20)]
        [DisplayName("Customer Last Name")]
        public string LastName { get; set; }
      
        public Customer()  // constructor so everytime we create an instance of customer it generates an 
            // we are generating the Id by code so we have more flexability on which db technoligies we can use later
        {
            this.Id = Guid.NewGuid().ToString(); // stored Id as a string. Generated the ID as a GUID and converted and stored The GUID as a string
        }
    }
}