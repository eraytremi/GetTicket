using AutoMapper;
using Azure;
using GetTicket.Business.Concrete;
using GetTicket.Business.CustomExceptions;
using GetTicket.DataAccess.Interfaces;
using GetTicket.Model.Dtos.BusJourneyDtos;
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
    public class BusJourneyService : IBusJourneyService
    {
        private readonly IBusJourneyRepository _busJourney;
        private readonly IMapper _mapper;

        public BusJourneyService(IBusJourneyRepository busJourney, IMapper mapper)
        {
            _busJourney = busJourney;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> AddJourneyAsync(PostBusJourneyDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("parametreler boş bırakılamaz");
            }
            
            var match= _mapper.Map<BusJourney>(dto);
            match.isActive = true;
            var list = await _busJourney.InsertAsync(match);
            return ApiResponse<NoData>.Success(StatusCodes.Status201Created);
        }

        public async Task<ApiResponse<List<BusJourneyDto>>> FindTicketAsync(string departurePoint, string destinationPoint, DateTime departureTime)
        {


            var list = await _busJourney.GetBusJourneysWithSameInClientDataAsync(departurePoint, destinationPoint, departureTime);


            if (list.Count>0)
            {
                
                return ApiResponse<List<BusJourneyDto>>.Success(StatusCodes.Status200OK, list);
            }
                    
            throw new BadRequestException("girilen değerler uyuşmadı");

        }

        public async Task<ApiResponse<List<BusJourneyDto>>> GetAllJourneysAsync()
        {
            
            var list = await _busJourney.GetAllWithoutParamsAsync(x=>x.isActive==true);
            if (list==null)
            {
                throw new NotFoundException("veri bulunamadı");
            }
            return ApiResponse<List<BusJourneyDto>>.Success(StatusCodes.Status200OK,list);
        }
        public async Task<ApiResponse<BusJourneyDto>> GetJourneyByIdAsync(int id)
        {
            if (id is <=0 )
            {
                throw new BadRequestException("id sıfırdan küçük  ve eşit olamaz!");
            }
            var listOfJourney = await _busJourney.GetByIdAsync(id);
            if (listOfJourney==null)
            {
                throw new NotFoundException("veri bulunamadı");
            }

            return ApiResponse<BusJourneyDto>.Success(StatusCodes.Status200OK,listOfJourney);
        }

        public async Task<ApiResponse<NoData>> RemoveJourneyAsync(int id)
        {
            var list = await _busJourney.BaseGetByIdAsync(id);
            if (list==null)
            {
                throw new BadRequestException("silinecek veri veritabanında kayıtlı değil!");
            }
            list.isActive = false;
            await _busJourney.UpdateAsync(list);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<NoData>> UpdateJourneyAsync(UpdateBusJourneyDto dto)
        {
            if (dto==null)
            {
                throw new BadRequestException("bilgileri boş bırakamazsın");
            }
            var list = _mapper.Map<BusJourney>(dto);
            list.isActive = true;
            await _busJourney.UpdateAsync(list);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
