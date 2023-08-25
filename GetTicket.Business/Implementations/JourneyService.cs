using AutoMapper;
using GetTicket.Business.Concrete;
using GetTicket.Business.CustomExceptions;
using GetTicket.Business.Profiles.BusFirmDtos;
using GetTicket.DataAccess.Implementations.Repositories;
using GetTicket.DataAccess.Interfaces;
using GetTicket.Model.Dtos.BusDtos;
using GetTicket.Model.Dtos.BusJourneyDtos;
using GetTicket.Model.Dtos.JourneyDtos;
using GetTicket.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Business.Abstract
{
    public class JourneyService : IJourneyService
    {
        private readonly IJourneyRepository _service;
        private readonly IMapper _mapper;
        public JourneyService(IJourneyRepository service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> AddAsync(PostJourneyDto dto)
        {
            if (dto == null)
                throw new BadRequestException("parametreler boş bırakılamaz");

            bool isSeatTaken = await IsSeatTaken(dto.BusJourneyID, dto.SeatNo);

            if (isSeatTaken)
            {
                throw new ConflictException("Bu koltuk zaten alınmış!!");
            }

            var matched = _mapper.Map<Journey>(dto);
            matched.IsActive = true;
            await _service.InsertAsync(matched);
            return ApiResponse<NoData>.Success(StatusCodes.Status201Created);
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var list = await _service.BaseGetByIdAsync(id);
            if (list == null)
            {
                throw new BadRequestException("silinecek veri, veritabanında kayıtlı değil!");
            }
            list.IsActive = false;
            await _service.UpdateAsync(list);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<GetJourneyDto>>> FindTicketAsync(string departurePoint, string destinationPoint, DateTime departureTime)
        {

            var list = await _service.GetJourneysWithSameInClientDataAsync(departurePoint, destinationPoint, departureTime);


            if (list.Count > 0)
            {
                var listOf = _mapper.Map<List<GetJourneyDto>>(list);
                return ApiResponse<List<GetJourneyDto>>.Success(StatusCodes.Status200OK, listOf);
            }

            throw new BadRequestException("girilen değerler uyuşmadı");
        }

        public async Task<ApiResponse<List<GetJourneyDto>>> GetAllJourneysAsync()
         {
            var list = await _service.GetAllWithoutParamsAsync(x => x.IsActive == true);
            if (list == null)
            {
                throw new NotFoundException("veri bulunamadı");
            }
            var listOf = _mapper.Map<List<GetJourneyDto>>(list);
            return ApiResponse<List<GetJourneyDto>>.Success(StatusCodes.Status200OK, listOf);
        }


        public async Task<ApiResponse<GetJourneyDto>> GetByJourneyIdAsync(int id)
        {
            if (id is <= 0)
            {
                throw new BadRequestException("id sıfırdan küçük  ve eşit olamaz!");
            }
            var getPassenger = await _service.GetByIdAsync(id);
            if (getPassenger == null)
            {
                throw new NotFoundException("veri bulunamadı");
            }
           
            return ApiResponse<GetJourneyDto>.Success(StatusCodes.Status200OK,getPassenger);
        }

        public async Task<ApiResponse<List<GetJourneyDto>>> GetByPassengerIdAsync(int id)
        {
           
            if (id is <= 0)
            {
                throw new BadRequestException("id sıfırdan küçük  ve eşit olamaz!");
            }
            var getPassenger = await _service.GetByPassengerIdAsync(id);
            if (getPassenger.IsNullOrEmpty())
            {
                throw new NotFoundException("veri bulunamadı");
            }
            var matched = _mapper.Map<List<GetJourneyDto>>(getPassenger);
            return ApiResponse<List<GetJourneyDto>>.Success(StatusCodes.Status200OK, matched);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(UpdateJourneyDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("bilgileri boş bırakamazsın");
            }
            var matched = _mapper.Map<Journey>(dto);
            matched.IsActive = true;
            await _service.UpdateAsync(matched);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }



        private async Task<bool> IsSeatTaken(int busJourneyID,int seatNo)
        {
            var existingJourney = await _service.GetByBusJourneyAndSeatAsync(busJourneyID, seatNo);
            return existingJourney!=null;
        }
    }
}
