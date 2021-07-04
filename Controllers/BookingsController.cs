using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MB.Taxi.Entities;
using The_Test.Data;
using AutoMapper;
using The_Test.Models;
using The_Test.Helpler.LookupService;
using The_Test.Models.Booking;

namespace The_Test.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILookupService _lookupService;


        public BookingsController(ApplicationDbContext context, IMapper mapper, ILookupService lookupService)
        {
            _context = context;
            _mapper = mapper;
            _lookupService = lookupService;
        }

        public async Task<IActionResult> Index()
        {
            var booking = await _context
                                 .Bookings
                                 .ToListAsync();


            var bookingVMs = _mapper.Map<List<Booking>, List<BookingVM>>(booking);

            return View(bookingVMs);
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context
                                .Bookings
                                .Include(booking => booking.Car)
                                .Include(booking => booking.Driver)
                                .Include(booking => booking.Passengers)
                                .Where(booking => booking.Id == id)
                                .FirstOrDefaultAsync();

            if (booking == null)
            {
                return NotFound();
            }

            var bookingVM = _mapper.Map<Booking, BookingVM>(booking);

            return View(bookingVM);
        }

        public async Task<IActionResult> Create()
        {
            var createEditBookingVM = new CreateEditBookingVM()
            {
                GetCarSelectList = await _lookupService.GetCarSelectList(),
                GetDriverSelectList = await _lookupService.GetDriverSelectList(),
                GetPassengerSelectList = await _lookupService.GetPassengerSelectList(),
                PaymentDate = DateTime.Now
            };


            return View(createEditBookingVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEditBookingVM bookingVM)
        {
            if (ModelState.IsValid)
            {
                var booking = _mapper.Map<CreateEditBookingVM, Booking>(bookingVM);

                if (bookingVM.PassengerIds.Count() > 0)
                {
                    var passenger = await _context
                                                  .Passengers
                                                  .Where(booking => bookingVM.PassengerIds.Contains(booking.Id))
                                                  .ToListAsync();
                    booking.Passengers.AddRange(passenger);
                }

                var driver = await _context.Drivers.FindAsync(bookingVM.DriverId);
                booking.Driver = driver;

                var car = await _context.Cars.FindAsync(bookingVM.CarId);
                booking.Car = car;

                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            bookingVM.GetPassengerSelectList = await _lookupService.GetPassengerSelectList();

            return View(bookingVM);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context
                                .Bookings
                                .FirstOrDefaultAsync(booking => booking.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            var bookingVM = _mapper.Map<Booking, CreateEditBookingVM>(booking);

            bookingVM.GetCarSelectList = await _lookupService.GetCarSelectList();
            bookingVM.GetDriverSelectList = await _lookupService.GetDriverSelectList();
            bookingVM.GetPassengerSelectList = await _lookupService.GetPassengerSelectList();
            bookingVM.PaymentDate = DateTime.Now;

            return View(bookingVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateEditBookingVM bookingVM)
        {
            if (id != bookingVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var booking = _mapper.Map<CreateEditBookingVM, Booking>(bookingVM);

                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(bookingVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookingVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PayBooking(int BookingId)
        {
            var booking = await _context.Bookings.FindAsync(BookingId);

            booking.IsPaid = true;
            booking.PaymentDate = DateTime.Now;

            _context.Update(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}
