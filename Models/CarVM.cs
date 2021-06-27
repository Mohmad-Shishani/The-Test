using Lucene.Net.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Test.Models
{
    public class CarVM
    {
        public CarVM()
            {
            var Drivers = new List<DriverVM>();
                     }
    public int Id { get; set; }

    [Required]
    [Display(Name = "Plate Number")]
    public string PlateNumber { get; set; }

    [Required]
    [Display(Name = "Name")]
    public string Name { get; set; }


    public DateTime MakeYear { get; set; }

    //public FuelType FuelType { get; set; }
    //public <CarType> CarType { get; set; }
    public List<DriverVM> Drivers { get; set; }
}
}
