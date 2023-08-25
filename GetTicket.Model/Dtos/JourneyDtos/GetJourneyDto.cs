using GetTicket.Model.Dtos.BusDtos;
using GetTicket.Model.Dtos.BusJourneyDtos;
using GetTicket.Model.Dtos.PassengerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Model.Dtos.JourneyDtos
{
    public class GetJourneyDto
    {
        public int JourneyID { get; set; }
        public int? SeatNo { get; set; }
        public bool IsActive { get; set; }
        public BusJourneyDto? BusJourneyDto { get; set; }
        public GetPassengerDto? GetPassengerDto  { get; set; }
    }
}
