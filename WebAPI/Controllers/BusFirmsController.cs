using GetTicket.Business.Concrete;
using GetTicket.Business.Profiles.BusFirmDtos;
using GetTicket.Model.Dtos.BusFirmDtos;
using GetTicket.Model.Dtos.PassengerDtos;
using GetTicket.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusFirmsController : BaseController
    {
        private readonly IBusFirmService _busfirm;

        public BusFirmsController(IBusFirmService busfirm)
        {
            _busfirm = busfirm;
        }

        

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(201, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]

        [HttpPost]
        public async Task<ActionResult> Add(PostBusFirmDto dto)
        {
            var response = await _busfirm.AddAsync(dto);
            return SendResponse(response);
        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var response = await _busfirm.DeleteAsync(id);
            return SendResponse(response);

        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [HttpPut]
        public async Task<ActionResult> Update(UpdateBusFirmDto dto)
        {
            var response = await _busfirm.UpdateAsync(dto);
            return SendResponse(response);
        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<GetBusFirmDto>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _busfirm.GetByIdAsync(id,"Buses");
            return SendResponse(response);
        }



        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<GetBusFirmDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = await _busfirm.GetBusFirmsAsync("Buses");
            return SendResponse(response);
        }
    }
}
