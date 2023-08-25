using GetTicket.Business.Profiles.BusFirmDtos;
using GetTicket.Model.Dtos.BusFirmDtos;
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
    public interface IBusFirmService
    {
        Task<ApiResponse<NoData>> AddAsync(PostBusFirmDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<NoData>> UpdateAsync(UpdateBusFirmDto dto);
        Task<ApiResponse<List<GetBusFirmDto>>> GetBusFirmsAsync(params string[] includeList);
        Task<ApiResponse<GetBusFirmDto>> GetByIdAsync(int id, params string[] includeList);
    }
}
