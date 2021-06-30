using MB.Taxi.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Taxi.Entities
{

    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int Rating { get; set; }
        public Gender Gender { get; set; }
        public List<Car> Car { get; set; }
    }
}
