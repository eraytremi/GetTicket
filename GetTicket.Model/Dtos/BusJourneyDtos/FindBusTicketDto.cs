using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Model.Dtos.BusJourneyDtos
{
    public class FindBusTicketDto
    {

        public string? DestinationPoint { get; set; }
        public string? DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }

    }
}
