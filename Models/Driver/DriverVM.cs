using MB.Taxi.Entities;
using MB.Taxi.Utils.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Test.Models
{
    public class DriverVM
    {
        public DriverVM()
        {
            Booking = new List<BookingVM>();
            Car = new List<CarVM>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }


        public int Rating { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public List<BookingVM> Booking { get; set; }
        public List<CarVM> Car { get; }
    }
}
