using GetTicket.DataAccess.Implementations.EF.Contexts;
using GetTicket.DataAccess.Interfaces;
using GetTicket.Model.Entities;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.DataAccess.Implementations.Repositories
{
    public class PassengerRepository:BaseRepositoryEf<Passenger,TransportationContext>,IPassengerRepository
    {
        public async Task<List<Passenger>> GetAllPassengersAsync(params string[] include)
        {
            return await GetAllAsync(x => x.isActive == true);
        }

        public async Task<Passenger> GetByIdAsync(int id, params string[] includeList)
        {
            var list = await GetAsync(p => p.PassengerID == id && p.isActive == true, includeList);
            return list;
        }
    }
}
