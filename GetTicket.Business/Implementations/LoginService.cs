using AutoMapper;
using GetTicket.Business.Concrete;
using GetTicket.Business.CustomExceptions;
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
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _repo;
        private readonly IMapper _mapper;
        public LoginService(ILoginRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<PassengerLoginDto>> SignInAsync(string Email, string Password)
        {

            var dataValue = await _repo.GetAsync(x => x.Email ==Email && x.Password ==Password && x.isActive==true );
            if (dataValue==null )
            {
                throw new NotFoundException("Kullanıcı bulunamadı");
            }
            var listOf= _mapper.Map<PassengerLoginDto>(dataValue);  
            return ApiResponse<PassengerLoginDto>.Success(StatusCodes.Status200OK,listOf);
            
            
        }
    }
}
