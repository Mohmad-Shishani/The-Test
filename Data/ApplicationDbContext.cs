using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MB.Taxi.Entities;

namespace The_Test.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MB.Taxi.Entities.Car> Car { get; set; }
        public DbSet<MB.Taxi.Entities.Driver> Driver { get; set; }
        public DbSet<MB.Taxi.Entities.Booking> Booking { get; set; }
        public DbSet<MB.Taxi.Entities.Passenger> Passenger { get; set; }
    }
}
