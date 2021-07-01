using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Test.Data;
using The_Test.Models.LookupVM;

namespace The_Test.Helpler.LookupService
{
    public class LookupService : ILookupService
    {
        private readonly ApplicationDbContext _context;
        public LookupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SelectList> GetCarSelectList()
        {
            var carsLookup = await _context
                                    .Cars
                                    .Select(car => new LookupVM()
                                    {
                                        Id = car.Id,
                                        Name = car.Name
                                    })
                                    .ToListAsync();

            var carSelectList = new SelectList(carsLookup, "Id", "Name");

            return carSelectList;
        }

        public async Task<SelectList> GetDriverSelectList()
        {
            var driversLookup = await _context
                                       .Drivers
                                       .Select(driver => new LookupVM()
                                       {
                                          Id = driver.Id,
                                          Name = driver.Name
                                       })
                                       .ToListAsync();

            var driverSelectList = new SelectList(driversLookup, "Id", "Name");

            return driverSelectList;
        }

        public async Task<SelectList> GetPassengerSelectList()
        {
            var passengersLookup = await _context
                                             .Passengers
                                             .Select(passenger => new LookupVM()
                                             {
                                                 Id = passenger.Id,
                                                 Name = passenger.Name
                                             })
                                             .ToListAsync();

            var passengerSelectList = new SelectList(passengersLookup, "Id", "Name");

            return passengerSelectList;
        }

    }
}
