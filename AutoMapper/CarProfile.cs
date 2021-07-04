using AutoMapper;
using MB.Taxi.Entities;
using The_Test.Models;
using The_Test.Models.Car;

namespace The_Test.AutoMapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarVM>().ReverseMap();
            CreateMap<Car, CreateEditCarVM>().ReverseMap();
        }
    }
}
