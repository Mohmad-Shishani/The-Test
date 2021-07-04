using MB.Taxi.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Taxi.Entities
{
    public class Passenger
    {
        public Passenger()
        {
            Booking = new List<Booking>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public List<Booking> Booking { get; set; }
    }
}
