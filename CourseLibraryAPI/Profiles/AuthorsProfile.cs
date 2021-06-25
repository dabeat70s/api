using AutoMapper;
using CourseLibrary.API.Entities;
using CourseLibrary.API.Helpers;
using CourseLibrary.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(
                    dest => dest.Name, 
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                    dest => dest.Age, 
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge(src.DateOfDeath)))
                .ForMember(
                dest=> dest.RebornAge,
                opt => opt.MapFrom(src=>src.DateOfReBorn.GetReBornAge(src.DateOfBirth,src.DateOfDeath))
                );
            CreateMap<AuthorForCreationDto, Author>();
            CreateMap<Author, AuthorFullDto>();
            CreateMap<AuthorForCreationWithDateOfDeathDto, Author>();
        }
    }
}
