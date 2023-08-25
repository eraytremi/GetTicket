using GetTicket.Model.Dtos.BusJourneyDtos;
using GetTicket.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Business.Concrete
{
    public interface IBusJourneyService
    {
        Task<ApiResponse<NoData>> AddJourneyAsync(PostBusJourneyDto dto);
        Task<ApiResponse<NoData>> RemoveJourneyAsync(int id);
        Task<ApiResponse<NoData>> UpdateJourneyAsync(UpdateBusJourneyDto dto);
        Task<ApiResponse<List<BusJourneyDto>>> GetAllJourneysAsync();
        Task<ApiResponse<BusJourneyDto>> GetJourneyByIdAsync(int id);
        Task<ApiResponse<List<BusJourneyDto>>> FindTicketAsync(string departurePoint, string destinationPoint, DateTime departureTime);

    }
}
