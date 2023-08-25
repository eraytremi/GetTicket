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
    public class LoginRepository : BaseRepositoryEf<Passenger, TransportationContext>, ILoginRepository
    {
     
    }
}
