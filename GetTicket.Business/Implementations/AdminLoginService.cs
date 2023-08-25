using GetTicket.Business.Concrete;
using GetTicket.DataAccess.Interfaces;
using GetTicket.Model.Dtos;
using GetTicket.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Business.Abstract
{
    public class AdminLoginService : IAdminLoginService
    {
        private readonly IAdminLoginRepository _repo;

        public AdminLoginService(IAdminLoginRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<AdminPanel>> SignInAsync(string Email, string Password)
        {
            var dataValue = await _repo.GetAsync(x => x.EMail == Email && x.Password == Password && x.IsActive == true);
            if (dataValue == null)
            {
                return ApiResponse<AdminPanel>.Fail(StatusCodes.Status404NotFound, "Kullanıcı bulunamadı");
            }
           
            return ApiResponse<AdminPanel>.Success(StatusCodes.Status200OK, dataValue);
        }
    }
}
