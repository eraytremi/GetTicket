using GetTicket.Business.Concrete;
using GetTicket.Model.Dtos;
using GetTicket.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController :BaseController
    {
        ILoginService _login;

        public SignInController(ILoginService login)
        {
            _login = login;
        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<PassengerLoginDto>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]

        [HttpGet("login")]
        public async Task<IActionResult> Login([FromQuery] string email, [FromQuery] string password )
        {

           var response = await _login.SignInAsync(email, password);
            return SendResponse(response);

        }
    }
}
