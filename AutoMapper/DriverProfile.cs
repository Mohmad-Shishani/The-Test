using AutoMapper;
using MB.Taxi.Entities;
using The_Test.Models;
using The_Test.Models.Driver;

namespace The_Test.AutoMapper
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<Driver, DriverVM>().ReverseMap();
            CreateMap<Driver, CreateEditDriverVM>().ReverseMap();

        }
    }
}
