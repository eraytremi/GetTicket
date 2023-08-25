using GetTicket.Model.Dtos.BusDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Business.Profiles.BusFirmDtos
{
    public class GetBusFirmDto
    {
        public int BusFirmID { get; set; }
        public string? BusFirmName { get; set; }
        public List<GetBusDto>? GetBusDto { get; set; }
    }
}
