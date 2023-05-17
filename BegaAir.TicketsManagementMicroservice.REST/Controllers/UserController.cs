using BegaAir.TicketsManagementMicroservice.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BegaAir.TicketsManagementMicroservice.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUserDetails()
        {
            var jwtToken = await HttpContext.GetTokenAsync("access_token");
            return Ok(JwtService.getUserFromJwt(jwtToken));
        }
    }
}
