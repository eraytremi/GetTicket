using GetTicket.Model.Dtos.BusJourneyDtos;
using GetTicket.Model.Dtos.PassengerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Model.Dtos.JourneyDtos
{
    public class UpdateJourneyDto
    {
        public int JourneyID { get; set; }
        public int? SeatNo { get; set; }
        public int PassengerID { get; set; }
        public int BusJourneyID { get; set; }
    }
}
