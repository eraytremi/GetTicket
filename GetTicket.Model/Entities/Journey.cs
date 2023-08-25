using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Model.Entities
{
    public class Journey:IEntity
    {
        public int JourneyID { get; set; }
        public int PassengerID { get; set; }
        public int BusJourneyID { get; set; }
        public int? SeatNo { get; set; }
        public bool IsActive { get; set; }
        public BusJourney? GetBusJourney { get; set; }
        public Passenger? GetPassenger { get; set; }
       

    }
}
