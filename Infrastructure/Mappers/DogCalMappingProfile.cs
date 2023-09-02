using AppCore.Models;
using AutoMapper;
using Infrastructure.Entities;

namespace Infrastructure.Mappers
{
    public class DogCalMappingProfile : Profile 
    {
        public DogCalMappingProfile()
        {
            CreateMap<Dog, DogEntity>()
                .ForMember(m => m.Name, c => c.MapFrom(s => s.Name))
                .ForMember(m => m.Age, c => c.MapFrom(s => s.Age))
                .ForMember(m => m.Gender, c => c.MapFrom(s => s.Gender))
                .ForMember(m => m.Weight, c => c.MapFrom(s => s.Weight))
                .ForMember(m => m.ActivityFactor, c => c.MapFrom(s => s.ActivityFactor))
                .ForMember(m => m.ActivityLevel, c => c.MapFrom(s => s.ActivityLevel))
                .ForMember(m => m.OwnerId, c => c.MapFrom(s => s.OwnerId));
            
        }
    }
}
