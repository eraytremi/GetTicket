using GetTicket.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.DataAccess.Implementations.EF.Contexts
{
    public class TransportationContext:DbContext
    {
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=TransportationDb;trusted_connection=true;");
        }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<BusJourney> BusJourneys { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusFirm> BusFirms { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<AdminPanel> AdminPanels { get; set; }




    }
}
