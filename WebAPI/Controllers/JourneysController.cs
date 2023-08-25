using GetTicket.Business.Concrete;
using GetTicket.Model.Dtos.BusJourneyDtos;
using GetTicket.Model.Dtos.JourneyDtos;
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
    
    public class JourneysController : BaseController
    {
        private readonly IJourneyService _service;

        public JourneysController(IJourneyService service)
        {
            _service = service;
        }



       
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<GetJourneyDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [HttpGet]

        
        public async Task<ActionResult> GetAllJourneys()
        {
            var response = await _service.GetAllJourneysAsync();
            return SendResponse(response);
        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<GetJourneyDto>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _service.GetByJourneyIdAsync(id);
            return SendResponse(response);

        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<GetJourneyDto>>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]

        [HttpGet("FindTicket")]
        public async Task<IActionResult> FindTicket([FromQuery] string departurePoint, [FromQuery] string destinationPoint, [FromQuery] string departureTime)
        {
            var response = await _service.FindTicketAsync(departurePoint, destinationPoint, Convert.ToDateTime(departureTime));
            return SendResponse(response);

        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<GetJourneyDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [HttpGet("getbypassengerid")]
        public async Task<ActionResult> GetByPassengerId([FromQuery] int id)
        {
            var response = await _service.GetByPassengerIdAsync(id);
            return SendResponse(response);

        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(201, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(409, Type = typeof(ApiResponse<NoData>))]
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] PostJourneyDto dto)
        {
            var response = await _service.AddAsync(dto);
            return SendResponse(response);
        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove([FromRoute] int id)
        {
            var response = await _service.DeleteAsync(id);
            return SendResponse(response);


        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateJourneyDto dto)
        {
            var response = await _service.UpdateAsync(dto);
            return SendResponse(response);


        }


    }
}
