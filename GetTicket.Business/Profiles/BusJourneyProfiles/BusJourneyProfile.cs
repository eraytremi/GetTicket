
using AutoMapper;
using GetTicket.Model.Dtos.BusJourneyDtos;
using GetTicket.Model.Entities;

namespace GetTicket.Business.Profiles.BusJourneyProfiles

{
    public class BusJourneyProfile : Profile
    {
        public BusJourneyProfile()
        {
            CreateMap<BusJourney, BusJourneyDto>()
                                                  .ForMember(dest => dest.BusDto,
                                                            opt => opt.MapFrom(src => src.Bus));

            CreateMap<BusJourney, FindBusTicketDto>();
            CreateMap<PostBusJourneyDto, BusJourney>();
            CreateMap<UpdateBusJourneyDto, BusJourney>();

        }
    }
}
