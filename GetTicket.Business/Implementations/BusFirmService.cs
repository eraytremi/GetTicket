using AutoMapper;
using GetTicket.Business.Concrete;
using GetTicket.Business.CustomExceptions;
using GetTicket.Business.Profiles.BusFirmDtos;
using GetTicket.DataAccess.Interfaces;
using GetTicket.Model.Dtos.BusFirmDtos;
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
    
    public class BusFirmService : IBusFirmService
    {

        private readonly IBusFirmRepository _busFirmRepository;
        private readonly IMapper _mapper;

        public BusFirmService(IBusFirmRepository busFirmRepository, IMapper mapper)
        {
            _busFirmRepository = busFirmRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> AddAsync(PostBusFirmDto dto)
        {
            if (dto == null)
                throw new BadRequestException("parametreler boş bırakılamaz");

            var match = _mapper.Map<BusFirm>(dto);
            match.isActive = true;
             await _busFirmRepository.InsertAsync(match);
            return ApiResponse<NoData>.Success(StatusCodes.Status201Created);
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var list = await _busFirmRepository.GetByIdAsync(id);
            if (list == null)
            {
                throw new BadRequestException("silinecek veri, veritabanında kayıtlı değil!");
            }
            list.isActive = false;
            await _busFirmRepository.UpdateAsync(list);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<GetBusFirmDto>> GetByIdAsync(int id, params string[] includeList)
        {
            if (id is <= 0)
            {
                throw new BadRequestException("id sıfırdan küçük  ve eşit olamaz!");
            }
            var getPassenger = await _busFirmRepository.GetByIdAsync(id, includeList);
            if (getPassenger == null)
            {
                throw new NotFoundException("veri bulunamadı");
            }
            var matched=_mapper.Map<GetBusFirmDto>(getPassenger);
            return ApiResponse<GetBusFirmDto>.Success(StatusCodes.Status200OK, matched);
        }

        public async Task<ApiResponse<List<GetBusFirmDto>>> GetBusFirmsAsync(params string[] includeList)
        {
            var list = await _busFirmRepository.GetAllAsync(x => x.isActive == true, includeList);
            if (list == null)
            {
                throw new NotFoundException("veri bulunamadı");
            }
            var listOf = _mapper.Map<List<GetBusFirmDto>>(list);
            return ApiResponse<List<GetBusFirmDto>>.Success(StatusCodes.Status200OK, listOf);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(UpdateBusFirmDto dto)
        {
             if (dto == null)
            {
                throw new BadRequestException("bilgileri boş bırakamazsın");
            }
            var matched = _mapper.Map<BusFirm>(dto);
            matched.isActive = true;
            await _busFirmRepository.UpdateAsync(matched);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
