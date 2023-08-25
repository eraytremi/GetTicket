using AutoMapper;
using Azure;
using GetTicket.Business.Concrete;
using GetTicket.Model.Dtos.BusJourneyDtos;
using GetTicket.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusJourneysController : BaseController
    {
        private readonly IBusJourneyService _busJourney;


        public BusJourneysController(IBusJourneyService busJourney)
        {
            _busJourney = busJourney;
        }


        [HttpGet]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<BusJourneyDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> GetBusJourneys()
        {
            var list = await _busJourney.GetAllJourneysAsync();
            return SendResponse(list);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<BusJourneyDto>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var response= await _busJourney.GetJourneyByIdAsync(id);
            return SendResponse(response);
        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<BusJourneyDto>>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]

        [HttpGet("FindTicket")]
        public async Task<IActionResult> FindTicket([FromQuery] string departurePoint, [FromQuery] string destinationPoint, [FromQuery] string departureTime)
        {
            var response = await _busJourney.FindTicketAsync(departurePoint,destinationPoint,Convert.ToDateTime(departureTime));
            return SendResponse(response);

        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(201, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [HttpPost]
        public async Task<IActionResult> AddBusJourney([FromBody]PostBusJourneyDto busJourney)
        {
            var response= await _busJourney.AddJourneyAsync(busJourney);
            return SendResponse(response);
        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<UpdateBusJourneyDto>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [HttpPut]
        public async Task<IActionResult> UpdateBusJourney([FromBody]UpdateBusJourneyDto busJourney)
        {
            var response = await _busJourney.UpdateJourneyAsync(busJourney);
            return SendResponse(response);
        }



        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<BusJourney>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusJourney([FromRoute]int id)
        {
            var response = await _busJourney.RemoveJourneyAsync(id);
            return SendResponse(response);
        }
    }
}
