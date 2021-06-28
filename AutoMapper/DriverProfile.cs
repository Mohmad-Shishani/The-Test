using AutoMapper;
using MB.Taxi.Entities;
using The_Test.Models;

namespace The_Test.AutoMapper
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<Driver, DriverVM>().ReverseMap();
        }
    }
}
