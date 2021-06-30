using MB.Taxi.Utils.Enums;
using System;

namespace MB.Taxi.Entities
{
    public class Car
    {

        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string Name { get; set; }
        public DateTime MakeYear { get; set; }
        public FuelType FuelType { get; set; }
        public CarType CarType { get; set; }
        public int? DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
