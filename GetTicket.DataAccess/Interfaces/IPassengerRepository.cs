using GetTicket.Model.Entities;
using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.DataAccess.Interfaces
{
    public interface IPassengerRepository:IBaseRepository<Passenger>
    {
        Task<Passenger> GetByIdAsync(int id, params string[] includeList);

        Task<List<Passenger>> GetAllPassengersAsync(params string[] include);
    }
}
