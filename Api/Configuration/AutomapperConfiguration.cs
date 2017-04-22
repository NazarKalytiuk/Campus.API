using AutoMapper;
using Domain.Models;
using DTO.DTOs;

namespace Api.Configuration
{
    public static class AutomapperConfiguration
    {
        public static void Load()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>()
                    .ForMember(dest => dest.GroupId, dto => dto.MapFrom(src => src.Group.Id))
                    .ForMember(dest => dest.StudentBookNumber, dto => dto.MapFrom(src => src.StudentBook.Number));
            });
        }
    }
}