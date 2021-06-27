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
        [Display(Name = "Price ")]
        public double Price { get; set; }
        public string IsPaid { get; set; }
        public List<CarVM> Cars { get; set; }
        public List<DriverVM> Drivers { get; set; }

        [Required]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }
    }
}
