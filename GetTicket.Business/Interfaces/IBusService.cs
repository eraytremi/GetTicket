using GetTicket.Model.Dtos.BusDtos;
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
    public interface IBusService
    {
        Task<ApiResponse<NoData>> AddAsync(PostBusDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<NoData>> UpdateAsync(UpdateBusDto dto);
        Task<ApiResponse<List<GetBusDto>>> GetBusesAsync(params string[] includeList);
        Task<ApiResponse<GetBusDto>> GetByIdAsync(int id, params string[] includeList);
    }
}
