using AutoMapper;
using GetTicket.Model.Dtos.BusDtos;
using GetTicket.Model.Dtos.BusJourneyDtos;
using GetTicket.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Business.Profiles.BusProfiles
{
    public class BusProfile : Profile
    {
        public BusProfile()
        {
            CreateMap<Bus, GetBusDto>().ForMember(dest => dest.BusFirmName,
                                                           opt => opt.MapFrom(src => src.BusFirm.BusFirmName == null ? "" : src.BusFirm.BusFirmName));
            CreateMap<PostBusDto, Bus>();
            CreateMap<UpdateBusDto, Bus>();

        }
    }
}
