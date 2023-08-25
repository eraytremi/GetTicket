using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Model.Entities
{
    public class BusJourney : IEntity
    {
        public int BusJourneyID { get; set; }
        public int BusID { get; set; }
        public string? DestinationPoint { get; set; }
        public string? DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal Price { get; set; }
        public bool isActive { get; set; }
        public Bus Bus { get; set; }
        public List<Journey> Journey { get; set; }

    }
}
