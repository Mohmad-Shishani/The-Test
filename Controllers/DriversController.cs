using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using The_Test.Data;
using AutoMapper;
using The_Test.Models;
using MB.Taxi.Entities;
using The_Test.Helpler.LookupService;
using The_Test.Models.Driver;

namespace The_Test.Controllers
{
    public class DriversController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILookupService _lookupService;
        public DriversController(ApplicationDbContext context, IMapper mapper, ILookupService lookupService)
        {
            _context = context;
            _mapper = mapper;
            _lookupService = lookupService;
        }

        public async Task<IActionResult> Index()
        {
            List<Driver> drivers = await _context
                                         .Drivers
                                         //.Include(driver => driver.Car)
                                         .ToListAsync();

            List<DriverVM> driverVMs = _mapper.Map<List<Driver>, List<DriverVM>>(drivers);

            return View(driverVMs);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context
                                 .Drivers
                                 .Include(driver => driver.Car)
                                 .FirstOrDefaultAsync(m => m.Id == id);

            if (driver == null)
            {
                return NotFound();
            }

            var DriverVM = _mapper.Map<Driver, DriverVM>(driver);

            return View(DriverVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DriverVM driverVM)
        {
            if (ModelState.IsValid)
            {
                var driver = _mapper.Map<DriverVM, Driver>(driverVM);

                _context.Add(driver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View(driverVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            var driverVM = _mapper.Map<Driver, DriverVM>(driver);

            return View(driverVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DriverVM driverVM)
        {
            if (id != driverVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var driver = _mapper.Map<DriverVM, Driver>(driverVM);

                    _context.Update(driver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverExists(driverVM.Id))
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


            return View(driverVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driver == null)
            {
                return NotFound();
            }
            var driverVM = _mapper.Map<Driver, DriverVM>(driver);

            return View(driverVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //public async Task<IActionResult> AddCourse(int studentId)
        //{
        //    var driverVM = new CreateEditDriverVM();

        //    carVM.DriverId = studentId;

        //    carVM.DriverName = await _context
        //                                .Drivers
        //                                .Where(student => student.Id == studentId)
        //                                .Select(student => student.FullName)
        //                                .SingleAsync();

        //    carVM.CarSelectList = await _lookupService.GetCarSelectList(driverVM);


        //    return View(courseVM);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddCar(CreateEditDriverVM createEditDriverVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var  car = await _context.Cars.FindAsync(carVM.Id);
        //        var driver = await _context.Drivers.FindAsync(carVM.DriverId);

        //        car.Driver.Add(driver);

        //        _context.Update(car);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(carVM);
        //}

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.Id == id);
        }
    }
}
