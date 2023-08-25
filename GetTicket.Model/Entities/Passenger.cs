using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Model.Entities
{
    public  class Passenger : IEntity
    {
        [Key]
        public int PassengerID { get; set; }
        public string? PassengerName { get; set; }
        public string? PassengerLastName { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? IDNumber { get; set; }
        public bool isActive { get; set; }
        public string? Email { get; set; }
        public DateTime? RegisterTime { get; set; }
        public Passenger()
        {
            RegisterTime = DateTime.Now;
        }
        public string? Gender { get; set; }

        public List<Journey> Journeys { get; set; }
    }
}
