using GetTicket.Model.Dtos.BusJourneyDtos;
using GetTicket.Model.Dtos.JourneyDtos;
using GetTicket.Model.Entities;
using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.DataAccess.Interfaces
{
    public interface IJourneyRepository:IBaseRepository<Journey>
    {
        Task<GetJourneyDto> GetByIdAsync(int id);
        Task<Journey> BaseGetByIdAsync(int id, params string[] includeList);
        Task<List<GetJourneyDto>> GetByPassengerIdAsync(int id);
        Task<Journey> GetByBusJourneyAndSeatAsync(int busJourneyID, int seatNo, params string[] includeList);
        Task<List<GetJourneyDto>> GetJourneysWithSameInClientDataAsync(string departurePoint, string destinationPoint, DateTime departureTime);
        Task<List<GetJourneyDto>> GetAllWithoutParamsAsync(Expression<Func<GetJourneyDto, bool>> expression = null);

    }
}
