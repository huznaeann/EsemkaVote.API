using EsemkaVote.API.Model.DTO;
using EsemkaVote.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsemkaVote.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingHeaderController : ControllerBase
    {
        private readonly IVotingHeaderService service;

        public VotingHeaderController(IVotingHeaderService service)
        {
            this.service = service;
        }

        [HttpGet("GetAllEvents")]
        [Authorize]
        public async Task<ActionResult<List<VotingHeaderResponse>>> GetAllEvents()
        {
            var events = await service.GetAllVoteEvents();

            return Ok(new
            {
                message = "",
                data = events
            });
        }
    }
}
