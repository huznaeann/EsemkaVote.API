using EsemkaVote.API.Model;
using EsemkaVote.API.Model.DTO;
using EsemkaVote.API.Repository;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{eventId}")]
        [Authorize]
        public async Task<ActionResult<List<CandidatesResponse>>> GetAllCandidates(int eventId)
        {
            var candidates = await service.GetAllCandidatesAsync(eventId);
            return Ok(new
            {
                message = "",
                Data = candidates
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VotingDetail?>> VoteCandidate(VoteCandidateRequest request)
        {
            var vote = await service.VoteCandidateAsync(request);

            if (vote == null)
            {
                return NotFound(new
                {
                    message = "Candidate or employee is not found",
                    data = vote
                });
            }

            return Ok(new
            {
                message = "Vote Successfull",
                data = ""
            });
        }
    }
}
