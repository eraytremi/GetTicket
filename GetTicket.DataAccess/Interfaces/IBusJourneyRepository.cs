using GetTicket.Model.Dtos;
using GetTicket.Model.Dtos.BusJourneyDtos;
using GetTicket.Model.Entities;
using Infrastructure.DataAccess;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.DataAccess.Interfaces
{
    public interface IBusJourneyRepository:IBaseRepository<BusJourney>
    {
        
        Task<BusJourneyDto> GetByIdAsync(int id);
        Task<BusJourney> BaseGetByIdAsync(int id, params string[] includeList);

        Task<List<BusJourneyDto>> GetBusJourneysWithSameInClientDataAsync(string departurePoint,string destinationPoint,DateTime departureTime);
        Task<List<BusJourneyDto>> GetAllWithoutParamsAsync(Expression<Func<BusJourneyDto, bool>> expression = null);
        Task<BusJourneyDto> GetWithoutParamsAsync(Expression<Func<BusJourneyDto, bool>> expression = null);
    }
}
