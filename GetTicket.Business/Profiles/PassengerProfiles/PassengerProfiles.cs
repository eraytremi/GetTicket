using AutoMapper;
using GetTicket.Model.Dtos;
using GetTicket.Model.Dtos.PassengerDtos;
using GetTicket.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Business.Profiles.PassengerProfiles
{
    public class PassengerProfiles:Profile
    {
        public PassengerProfiles()
        {
            CreateMap<Passenger, GetPassengerDto>();
            CreateMap<Passenger, PassengerLoginDto>();
            CreateMap<PostPassengerDto, Passenger>();
            CreateMap<UpdatePassengerDto, Passenger>();
            CreateMap<RegisterDto, Passenger>();


        }
    }
}
