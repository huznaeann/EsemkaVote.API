using EsemkaVote.API.Model.DTO;
using EsemkaVote.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
                    message = "email or password is wrong",
                    data = ""
                });
            }

            return Ok(new
            {
                message = "Login Success",
                data = response
            });
        }

        [HttpGet("Me")]
        [Authorize]
        public async Task<ActionResult> GetMe()
        {
            int employeeId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var findEmployee = await service.GetMeAsync(employeeId);

            if (findEmployee != null)
            {
                return Ok(new
                {
                    message = "success",
                    data = findEmployee
                });
            }

            return Unauthorized(new
            {
                message = "Please login first",
                data = ""
            });
        }
    }
}
