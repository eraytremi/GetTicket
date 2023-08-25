using GetTicket.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Business.Concrete
{
    public interface IAdminLoginService
    {
        Task<ApiResponse<AdminPanel>> SignInAsync(string Email, string Password);

    }
}
