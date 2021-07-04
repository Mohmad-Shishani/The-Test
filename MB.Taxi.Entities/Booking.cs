using System;
using System.Collections.Generic;

namespace MB.Taxi.Entities
{
    public class Booking
    {
        public Booking()
        {
            Passengers = new List<Passenger>();
        }
        public int Id { get; set; }
        public DateTime PickUpTime { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public double Price { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PaymentDate { get; set; }

        public Car Car { get; set; }
        public Driver Driver { get; set; }
        public List<Passenger> Passengers { get; set; }
    }
}
