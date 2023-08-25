using AutoMapper;
using GetTicket.Business.Concrete;
using GetTicket.Business.CustomExceptions;
using GetTicket.DataAccess.Implementations.Repositories;
using GetTicket.DataAccess.Interfaces;
using GetTicket.Model.Dtos.BusDtos;
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
    public class BusService : IBusService
    {

        private readonly IBusRepository _busrepository;
        private readonly IMapper _mapper;

        public BusService(IBusRepository busrepository, IMapper mapper)
        {
            _busrepository = busrepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> AddAsync(PostBusDto dto)
        {
            if (dto == null)
                throw new BadRequestException("parametreler boş bırakılamaz");

            var matched = _mapper.Map<Bus>(dto);
            matched.isActive = true;
            await _busrepository.InsertAsync(matched);
            return ApiResponse<NoData>.Success(StatusCodes.Status201Created);
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var list = await _busrepository.GetByIdAsync(id);
            if (list == null)
            {
                throw new BadRequestException("silinecek veri, veritabanında kayıtlı değil!");
            }
            list.isActive = false;
            await _busrepository.UpdateAsync(list);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<GetBusDto>> GetByIdAsync(int id, params string[] includeList)
        {
            if (id is <= 0)
            {
                throw new BadRequestException("id sıfırdan küçük  ve eşit olamaz!");
            }
            var getPassenger = await _busrepository.GetByIdAsync(id, includeList);
            if (getPassenger == null)
            {
                throw new NotFoundException("veri bulunamadı");
            }
            var matched = _mapper.Map<GetBusDto>(getPassenger);
            return ApiResponse<GetBusDto>.Success(StatusCodes.Status200OK, matched);
        }

        public async Task<ApiResponse<List<GetBusDto>>> GetBusesAsync(params string[] includeList)
        {
            

            var list = await _busrepository.GetAllAsync(x => x.isActive == true, includeList);
            if (list == null)
            {
                throw new NotFoundException("veri bulunamadı");
            }
            var listOf = _mapper.Map<List<GetBusDto>>(list);
            return ApiResponse<List<GetBusDto>>.Success(StatusCodes.Status200OK, listOf);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(UpdateBusDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("bilgileri boş bırakamazsın");
            }
            var matched = _mapper.Map<Bus>(dto);
            matched.isActive = true;
            await _busrepository.UpdateAsync(matched);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
