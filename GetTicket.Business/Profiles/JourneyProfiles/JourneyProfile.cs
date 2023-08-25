using AutoMapper;
using GetTicket.Business.Profiles.BusFirmDtos;
using GetTicket.Model.Dtos;
using GetTicket.Model.Dtos.JourneyDtos;
using GetTicket.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Business.Profiles.JourneyProfiles
{
    public class JourneyProfile : Profile
    {
        public JourneyProfile()
        {
            CreateMap<Journey, GetJourneyDto>()
                .ForMember(dest => dest.BusJourneyDto, opt => opt.MapFrom(src => src.GetBusJourney))
                .ForMember(dest => dest.GetPassengerDto, opt => opt.MapFrom(src => src.GetPassenger));
                                               
  

            CreateMap<PostJourneyDto, Journey>();
            CreateMap<UpdateJourneyDto, Journey>();


        }
    }
}
