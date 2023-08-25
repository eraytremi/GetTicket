using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Model.Entities
{
    public class AdminPanel:IEntity
    {
        [Key]
        public int AdminId { get; set; }
        public string? EMail { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public bool IsActive { get; set; }
    }
}
