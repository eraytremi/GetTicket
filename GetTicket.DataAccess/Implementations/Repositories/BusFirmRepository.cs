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
    public class BusFirmRepository : BaseRepositoryEf<BusFirm, TransportationContext>, IBusFirmRepository
    {
        public async Task<BusFirm> GetByIdAsync(int id, params string[] includeList)
        {
            var list = await GetAsync(p => p.BusFirmID == id && p.isActive == true, includeList);
            return list;
        }
    }
}
