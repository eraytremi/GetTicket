using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Model.Dtos.BusDtos
{
    public class PostBusDto
    {
        public int? BusFirmID { get; set; }
        public string? BusPlate { get; set; }
        public string? ModelOfBus { get; set; }
        public int? CapacityOfSeat { get; set; }
    }
}
