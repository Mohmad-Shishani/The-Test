using MB.Taxi.Utils.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Test.Models
{
    public class PassengersVM
    {
        public int Id { get; set; }

        [Required]
        [Display (Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
    }
}
