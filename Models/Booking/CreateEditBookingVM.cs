using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace The_Test.Models.Booking
{
    public class CreateEditBookingVM
    {
        public CreateEditBookingVM()
        {
            PassengerIds = new List<int>();
        }

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
        public DateTime PaymentDate { get; set; }


        public int CarId { get; set; }
        public SelectList GetCarSelectList { get; set; }

        public int DriverId { get; set; }
        public SelectList GetDriverSelectList { get; set; }

        public List<int> PassengerIds { get; set; }
        public SelectList GetPassengerSelectList { get; set; }

    }
}
