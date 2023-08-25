using GetTicket.Business.Concrete;
using GetTicket.Model.Dtos.PassengerDtos;
using GetTicket.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController :BaseController
    {
        private readonly IPassengerService _passenger;

        public PassengersController(IPassengerService passenger)
        {
            _passenger = passenger;
        }


        
       


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(201, Type = typeof(ApiResponse<Passenger>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        
        [HttpPost]
        public async Task<ActionResult> Add(PostPassengerDto dto) 
        {
            var response = await _passenger.AddAsync(dto);
            return SendResponse(response);
        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            var response = await _passenger.DeleteAsync(id);
            return SendResponse(response);

        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody]UpdatePassengerDto dto)
        {
            var response = await _passenger.UpdateAsync(dto);
            return SendResponse(response);
        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<GetPassengerDto>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute]int id)
        {
            var response = await _passenger.GetByIdAsync(id);
            return SendResponse(response);
        }



        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<GetPassengerDto>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = await _passenger.GetPassengersAsync();
            return SendResponse(response);
        }



    }
}
