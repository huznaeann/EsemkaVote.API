using EsemkaVote.API.Model.DTO;
using EsemkaVote.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsemkaVote.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;

        public AuthController(IAuthService service)
        {
            this.service = service;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO request)
        {
            var response = await service.LoginAsync(request);

            if (response == null)
            {
                return NotFound(new
                {
                    message = "Data not found",
                    data = ""
                });
            }

            return Ok(new
            {
                message = "Login Success",
                Data = response
            });
        }
    }
}
