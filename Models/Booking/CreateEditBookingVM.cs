using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Test.Models.Booking
{
    public class CreateEditBookingVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pickup Time")]
        public DateTime PickUpTime { get; set; }

        [Required]
        [Display(Name = "From Address ")]
        public string FromAddress { get; set; }

        [Required]
        [Display(Name = "To Address")]
        public string ToAddress { get; set; }

        [Required]
        public double Price { get; set; }

        public bool IsPaid { get; set; }


        [Required]
        [Display(Name = "Car")]
        public CarVM Car { get; set; }

        [Required]
        [Display(Name = "Driver")]
        public DriverVM Driver { get; set; }

        [Required]
        public List<PassengerVM> Passenger { get; set; }

        public DateTime PaymentDate { get; set; }

        public SelectList CarSelectList { get; set; }
        public SelectList DriverSelectList { get; set; }
        public SelectList PassengerSelectList { get; set; }
    }
}
