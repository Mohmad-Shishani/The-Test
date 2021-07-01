using MB.Taxi.Utils.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Test.Models.Driver
{
    public class CreateEditDriverVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }


        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [Required]
        public Gender Gender { get; set; }


        [Display(Name = "Cars")]
        public List<int> CarIds { get; set; }

        public int DriverId { get; set; }
        public string DriverName { get; set; }

        public SelectList CarSelectList { get; set; }

    }
}
