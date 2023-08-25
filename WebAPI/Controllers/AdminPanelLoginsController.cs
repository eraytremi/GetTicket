using GetTicket.Business.Concrete;
using GetTicket.Model.Dtos;
using GetTicket.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Infrastructure.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPanelLoginsController : BaseController
    {
        private readonly IAdminLoginService _service;
        private readonly IConfiguration _configuration;
        public AdminPanelLoginsController(IAdminLoginService service, IConfiguration configuration = null)
        {
            _service = service;
            _configuration = configuration;
        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<AccessToken>))]
        [HttpGet("gettoken")]
        public async Task<ActionResult> ProduceToken()
        {
            var accessToken=  new JwtGenerator(_configuration).GenerateAccessToken();
            var response = new ApiResponse<AccessToken>();
            response.Data = accessToken;
            response.StatusCode = 200;
            return SendResponse(response);
        }



        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<AdminPanel>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [HttpGet("login")]
        
        public async Task<ActionResult> SignIn([FromQuery] string Email, [FromQuery]string Password)
        {
            var response = await _service.SignInAsync(Email, Password);
            return SendResponse(response);
        }
    }
}
