using GetTicket.Business.Concrete;
using GetTicket.Model.Dtos.BusDtos;
using GetTicket.Model.Dtos.PassengerDtos;
using GetTicket.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : BaseController
    {
        private readonly IBusService _busService;

        public BusesController(IBusService busService)
        {
            _busService = busService;
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(201, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]

        [HttpPost]
        public async Task<ActionResult> Add(PostBusDto dto)
        {
            var response = await _busService.AddAsync(dto);
            return SendResponse(response);
        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var response = await _busService.DeleteAsync(id);
            return SendResponse(response);

        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [HttpPut]
        public async Task<ActionResult> Update(UpdateBusDto dto)
        {
            var response = await _busService.UpdateAsync(dto);
            return SendResponse(response);
        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<GetBusDto>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _busService.GetByIdAsync(id,"BusFirm");
            return SendResponse(response);
        }



        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<GetBusDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = await _busService.GetBusesAsync("BusFirm");
            return SendResponse(response);
        }
    }
}
