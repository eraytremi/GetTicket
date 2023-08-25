using GetTicket.Model.Dtos.BusDtos;
using GetTicket.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Model.Dtos.BusJourneyDtos
{
    public class BusJourneyDto
    {
        public int BusJourneyID { get; set; }
        public string? DestinationPoint { get; set; }
        public string? DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal Price { get; set; }
        public bool isActive { get; set; }
        public GetBusDto BusDto { get; set; }

    }
}
