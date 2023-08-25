using GetTicket.Business.Profiles.BusFirmDtos;
using GetTicket.Model.Dtos.BusFirmDtos;
using GetTicket.Model.Dtos.BusJourneyDtos;
using GetTicket.Model.Dtos.JourneyDtos;
using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Business.Concrete
{
    public interface IJourneyService
    {
        Task<ApiResponse<NoData>> AddAsync(PostJourneyDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<NoData>> UpdateAsync(UpdateJourneyDto dto);
        Task<ApiResponse<List<GetJourneyDto>>> GetAllJourneysAsync();
        Task<ApiResponse<GetJourneyDto>> GetByJourneyIdAsync(int id);
        Task<ApiResponse<List<GetJourneyDto>>> GetByPassengerIdAsync(int id);
        Task<ApiResponse<List<GetJourneyDto>>> FindTicketAsync(string departurePoint, string destinationPoint, DateTime departureTime);

    }
}
