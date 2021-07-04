using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Test.Models
{
    public class BookingVM
    {
        public BookingVM()
        {
            Passengers = new List<PassengerVM>();
        }
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
        [Display(Name = "Is it Paid ?")]
        public bool IsPaid { get; set; }

        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }

        public CarVM Car { get; set; }
        public DriverVM Driver { get; set; }
        public List<PassengerVM> Passengers { get; set; }
    }
}
