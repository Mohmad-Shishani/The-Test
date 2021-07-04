using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Test.Helpler.LookupService
{
    public interface ILookupService
    {
        public Task<SelectList> GetCarSelectList();
        public Task<SelectList> GetDriverSelectList();
        public Task<MultiSelectList> GetPassengerSelectList();
        public Task<SelectList> GetBookingSelectList();
    }
}
