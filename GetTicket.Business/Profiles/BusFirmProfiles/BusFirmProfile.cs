using AutoMapper;
using GetTicket.Business.Profiles.BusFirmDtos;
using GetTicket.Model.Dtos.BusFirmDtos;
using GetTicket.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Business.Profiles.BusFirmProfiles
{
    public class BusFirmProfile : Profile
    {
        public BusFirmProfile()
        {
            CreateMap<BusFirm, GetBusFirmDto>().ForMember(dest => dest.GetBusDto, opt => opt.MapFrom(src => src.Buses));
            CreateMap<PostBusFirmDto, BusFirm>();
            CreateMap<UpdateBusFirmDto, BusFirm>();

        }
    }
}
