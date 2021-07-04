using AutoMapper;
using MB.Taxi.Entities;
using The_Test.Models;
using The_Test.Models.Booking;

namespace The_Test.AutoMapper
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingVM>().ReverseMap();
            CreateMap<Booking, CreateEditBookingVM>().ReverseMap();
        }
    }
}
