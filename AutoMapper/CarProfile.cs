using AutoMapper;
using MB.Taxi.Entities;
using The_Test.Models;

namespace The_Test.AutoMapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarVM>().ReverseMap();
        }
    }
}
