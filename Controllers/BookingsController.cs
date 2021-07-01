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


        public BookingsController(ApplicationDbContext context, IMapper mapper , ILookupService lookupService)
        {
            _context = context;
            _mapper = mapper;
            _lookupService = lookupService;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = await _context
                                 .Bookings
                                 .Include(booking => booking.Car)
                                 .Include(booking => booking.Driver)
                                 .Include(booking => booking.Passenger)
                                 .ToListAsync();


            var bookingVMs = _mapper.Map<List<Booking>, List<BookingVM>>(bookings);

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
                                .Include(booking => booking.Passenger)
                                .FirstOrDefaultAsync(m => m.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            var bookingVM = _mapper.Map<Booking, BookingVM>(booking);

            return View(bookingVM);
        }

        public async Task<IActionResult> CreateAsync()
        {
            var createEditBookingVM = new CreateEditBookingVM();

            createEditBookingVM.CarSelectList = await _lookupService.GetCarSelectList();
            createEditBookingVM.DriverSelectList = await _lookupService.GetDriverSelectList();
            createEditBookingVM.PassengerSelectList = await _lookupService.GetPassengerSelectList();

            return View(createEditBookingVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEditBookingVM bookingVM)
        {
            if (ModelState.IsValid)
            {

                var booking = _mapper.Map<CreateEditBookingVM, Booking>(bookingVM);

                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var createEditBookingVM = new CreateEditBookingVM();

            createEditBookingVM.CarSelectList = await _lookupService.GetCarSelectList();
            createEditBookingVM.DriverSelectList = await _lookupService.GetDriverSelectList();
            createEditBookingVM.PassengerSelectList = await _lookupService.GetPassengerSelectList();

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
                                .Include(booking => booking.Car)
                                .Include(booking => booking.Driver)
                                .FirstOrDefaultAsync(m => m.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            var bookingVM = _mapper.Map<Booking,CreateEditBookingVM>(booking);

            bookingVM.CarSelectList = await _lookupService.GetCarSelectList();
            bookingVM.DriverSelectList = await _lookupService.GetDriverSelectList();
            bookingVM.PassengerSelectList = await _lookupService.GetPassengerSelectList();

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

            var bookingVM = _mapper.Map<Booking, BookingVM>(booking);

            return View(bookingVM);
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
        public async Task<IActionResult> PayForBooking(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);

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
