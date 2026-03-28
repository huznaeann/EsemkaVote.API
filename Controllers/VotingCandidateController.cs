using EsemkaVote.API.Model;
using EsemkaVote.API.Model.DTO;
using EsemkaVote.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsemkaVote.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingCandidateController : ControllerBase
    {
        private readonly IVotingCandidateService service;

        public VotingCandidateController(IVotingCandidateService service)
        {
            this.service = service;
        }

        [HttpGet("GetAllCandidate/{eventId}")]
        public async Task<ActionResult<List<CandidatesResponse>>> GetAllCandidates(int eventId)
        {
            var candidates = await service.GetAllCandidatesAsync(eventId);
            return Ok(new
            {
                message = "",
                Data = candidates
            });
        }

        [HttpPost("VoteCandidate")]
        public async Task<ActionResult<VotingDetail>> VoteCandidate(VoteCandidateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Bad Request",
                    data = ""
                });
            }

            var vote = await service.VoteCandidateAsync(request);

            return Ok(new
            {
                message = "Vote Successfull",
                data = vote
            });
        }
    }
}
