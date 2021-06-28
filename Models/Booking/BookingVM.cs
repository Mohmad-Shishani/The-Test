using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Test.Models
{
    public class BookingVM
    {
        public int Id { get; set; }

        [Required]
        [Display (Name ="Pickup Time")]
        public DateTime PickUpTime { get; set; }

        [Required]
        [Display(Name = "From Address ")]
        public string FromAddress { get; set; }

        [Required]
        [Display(Name = "To Address")]
        public string ToAddress { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Is Paid ")]
        public bool IsPaid { get; set; }

        [Required]
        [Display(Name = "Car")]

        public List<CarVM> Cars { get; set; }

        [Required]
        [Display(Name = "Driver")]
        public List<DriverVM> Drivers { get; set; }

        [Required]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }
    }
}
