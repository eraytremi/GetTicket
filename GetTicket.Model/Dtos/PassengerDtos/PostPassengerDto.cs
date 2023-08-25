using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Model.Dtos.PassengerDtos
{
    public class PostPassengerDto
    {

        public string? PassengerName { get; set; }
        public string? PassengerLastName { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? IDNumber { get; set; }
        public string? Email { get; set; }
        public DateTime? RegisterTime { get; set; }

        public PostPassengerDto()
        {
            RegisterTime = DateTime.Now;
        }
        public string? Gender { get; set; }
       

    }
}
