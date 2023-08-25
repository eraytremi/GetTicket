using GetTicket.DataAccess.Implementations.EF.Contexts;
using GetTicket.DataAccess.Interfaces;
using GetTicket.Model.Entities;
using Infrastructure.DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.DataAccess.Implementations.Repositories
{
    public class BusRepository : BaseRepositoryEf<Bus, TransportationContext>, IBusRepository
    {
        public async Task<Bus> GetByIdAsync(int id, params string[] includeList)
        {
            var list = await GetAsync(p => p.BusID == id && p.isActive == true, includeList);
            return list;
        }
    }
}
