using GetTicket.Business.Concrete;
using GetTicket.Model.Dtos.PassengerDtos;
using GetTicket.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : BaseController
    {
        private readonly IPassengerService _passenger;

        public RegistersController(IPassengerService passenger)
        {
            _passenger = passenger;
        }



        [Produces("application/json", "text/plain")]
        [ProducesResponseType(201, Type = typeof(ApiResponse<Passenger>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]

        [HttpPost]
        public async Task<ActionResult> SignUp([FromBody] RegisterDto register)
        {
            var response = await _passenger.RegisterAsync(register);
            return SendResponse(response);
        }
    }
}
