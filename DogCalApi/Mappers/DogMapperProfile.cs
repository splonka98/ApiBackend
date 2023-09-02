using AppCore.Models;
using AutoMapper;
using DogCalApi.Dto;
using Infrastructure.Entities;

namespace DogCalApi.Mappers
{
    public class DogMapperProfile : Profile
    {
        public DogMapperProfile()
        {
            CreateMap<Dog, AddDogDto>()
                .ForMember(m => m.Name, d => d.MapFrom(s => s.Name))
                .ForMember(m => m.Age, d => d.MapFrom(s => s.Age))
                .ForMember(m => m.Gender, d => d.MapFrom(s => s.Gender))
                .ForMember(m => m.Weight, d => d.MapFrom(s => s.Weight))
                .ForMember(m => m.ActivityLevel, d => d.MapFrom(s => s.ActivityLevel));
            CreateMap<Dog, DogEntity>();


        }
    }
}
