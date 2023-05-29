using AutoMapper;
using Sample_Project.entities.Auth;
using Sample_Project.entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.entities.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //    CreateMap<T, TDto>().ReverseMap();
            //    CreateMap<T, TDto>();
      
            CreateMap<User, SessionDetailsViewModel>()
           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));


        }
    }
}
