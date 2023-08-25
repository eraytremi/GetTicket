using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Model.Entities
{
    public  class Bus : IEntity
    {
        [Key]
        public int BusID { get; set; }
        public int BusFirmID { get; set; }
        public string? BusPlate { get; set; }
        public string? ModelOfBus { get; set; }
        public int? CapacityOfSeat { get; set; }
        public bool isActive { get; set; }
        public BusFirm? BusFirm { get; set; }
        public List<BusJourney> BusJourneys { get; set; }
    }
}
