using GetTicket.Model.Dtos.PassengerDtos;
using GetTicket.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Business.Concrete
{
    public interface IPassengerService
    {
        Task<ApiResponse<NoData>> AddAsync(PostPassengerDto product);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<NoData>> UpdateAsync(UpdatePassengerDto product);
        Task<ApiResponse<List<GetPassengerDto>>> GetPassengersAsync(params string[] includeList);
        Task<ApiResponse<GetPassengerDto>> GetByIdAsync(int id, params string[] includeList);
        Task<ApiResponse<Passenger>> RegisterAsync(RegisterDto passenger);


    }
}
