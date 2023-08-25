using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Model.Entities
{
    public class BusFirm : IEntity
    {
        public int BusFirmID { get; set; }
        public string? BusFirmName { get; set; }
        public bool isActive { get; set; }
        public List<Bus>? Buses { get; set; }
        
    }
}
