using AutoMapper;
using GetTicket.Business.Concrete;
using GetTicket.Business.CustomExceptions;
using GetTicket.Business.FluentValidation.RegisterValidation;
using GetTicket.DataAccess.Interfaces;
using GetTicket.Model.Dtos.BusJourneyDtos;
using GetTicket.Model.Dtos.PassengerDtos;
using GetTicket.Model.Entities;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Business.Abstract
{
    public class PassengerService : IPassengerService
    {
         private readonly IPassengerRepository _repository;
         private readonly IMapper _mapper;

        public PassengerService(IMapper mapper, IPassengerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ApiResponse<NoData>> AddAsync(PostPassengerDto product)
        {
            if (product == null)
             throw new BadRequestException("parametreler boş bırakılamaz");
            
            var match = _mapper.Map<Passenger>(product);
            match.isActive = true;
            await _repository.InsertAsync(match);
            return ApiResponse<NoData>.Success(StatusCodes.Status201Created);
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var list = await _repository.GetByIdAsync(id);
            if (list == null)
            {
                throw new BadRequestException("silinecek veri, veritabanında kayıtlı değil!");
            }
            list.isActive = false;
            await _repository.UpdateAsync(list);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<GetPassengerDto>> GetByIdAsync(int id, params string[] includeList)
        {
            if (id is <= 0)
            {
                throw new BadRequestException("id sıfırdan küçük  ve eşit olamaz!");
            }
            var getPassenger = await _repository.GetByIdAsync(id, includeList);
            if (getPassenger == null)
            {
                throw new NotFoundException("veri bulunamadı");
            }
            var list = _mapper.Map<GetPassengerDto>(getPassenger);

            return ApiResponse<GetPassengerDto>.Success(StatusCodes.Status200OK, list);
        }

        public async Task<ApiResponse<List<GetPassengerDto>>> GetPassengersAsync(params string[] includeList)
        {

            var list = await _repository.GetAllPassengersAsync();
            if (list == null)
            {
                throw new NotFoundException("veri bulunamadı");
            }
            var listOfDto = _mapper.Map<List<GetPassengerDto>>(list);
            return ApiResponse<List<GetPassengerDto>>.Success(StatusCodes.Status200OK, listOfDto);
        }

        public async Task<ApiResponse<Passenger>> RegisterAsync(RegisterDto dto)
        {


            var validator = new RegisterValidation();

            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                throw new BadRequestException(string.Join(",", errorMessages));
            }
           
            var select = _repository.GetAsync(x => x.Email == dto.Email || x.Phone == dto.Phone || x.IDNumber == dto.IDNumber);
            if (select == null)
            {
                throw new BadRequestException("Aynı değerde kayıtlı bir kullanıcı var. Farklı değer dene");
            }
            var insert = _mapper.Map<Passenger>(dto);
            insert.isActive = true;
            var response = await _repository.InsertAsync(insert);
            

            return ApiResponse<Passenger>.Success(StatusCodes.Status201Created,response);
            
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(UpdatePassengerDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("bilgileri boş bırakamazsın");
            }
            var list = _mapper.Map<Passenger>(dto);
            list.isActive = true;
            await _repository.UpdateAsync(list);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
    
}
