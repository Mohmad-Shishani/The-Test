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
            var driver  = await _context
                                         .Drivers
                                         .ToListAsync();

            var driverVM  = _mapper.Map<List<Driver>, List<DriverVM>>(driver);

            return View(driverVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context
                                 .Drivers
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

            var driver = await _context
                                .Drivers
                                .FirstOrDefaultAsync(x => x.Id == id); 

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


        public async Task<IActionResult> AddCar(int? Id)
        {
            var driver = await _context
                                .Drivers
                                .Where(x => x.Id == Id)
                                .SingleOrDefaultAsync();

            var driverVM = _mapper.Map<Driver, CreateEditDriverVM>(driver);

            driverVM.GetCarSelectList = await _lookupService.GetCarSelectList();

            return View(driverVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCarSave(int? Id, int CarId )
        {
            var driver = await _context.Drivers.FindAsync(Id);

            var car = await _context.Cars.FindAsync(CarId);
            driver.Car.Add(car);

            _context.Update(driver);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }




        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.Id == id);
        }
    }
}
