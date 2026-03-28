using EsemkaVote.API.Data;
using EsemkaVote.API.Model;
using EsemkaVote.API.Model.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EsemkaVote.API.Repository
{
    public class VotingHeaderService(EsemkaVoteAPIDataContext db) : IVotingHeaderService
    {
        public async Task<List<VotingHeaderResponse>?> GetAllVoteEvents()
        {
            var events = await db.VotingHeaders
                .Select(e => new VotingHeaderResponse
                {
                    id = e.id,
                    name = e.name,
                    description = e.description,
                    startDate = e.startDate,
                    endDate = e.endDate,
                    voters = db.VotingDetails
                            .Where(v => v.VotingCandidate.VotingHeader.id == e.id)
                            .Count()
                })
                .ToListAsync();

            return events;
        }

        public int CountVoters(int eventId)
        {
            return db.VotingDetails
                .Where(v => v.VotingCandidate.VotingHeader.id == eventId)
                .Count();
        }
    }
}
