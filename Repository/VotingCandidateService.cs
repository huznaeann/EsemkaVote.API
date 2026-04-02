using EsemkaVote.API.Data;
using EsemkaVote.API.Model;
using EsemkaVote.API.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace EsemkaVote.API.Repository
{
    public class VotingCandidateService(EsemkaVoteAPIDataContext db) : IVotingCandidateService
    {
        public async Task<List<CandidatesResponse>> GetAllCandidatesAsync(int votingHeaderId)
        {
            var candidates = await db.VotingCandidates
                .Where(c => c.votingHeaderId == votingHeaderId)
                .Select(c => new CandidatesResponse
                {
                    candidateId = c.id,
                    name = c.Employee.name,
                    division = c.Employee.division,
                    photo = c.Employee.photo
                })
                .ToListAsync();

            return candidates;
        }

        public async Task<VotingDetail?> VoteCandidateAsync(VoteCandidateRequest request)
        {
            var findEmployee = await db.Employees.AnyAsync(e => e.id == request.employeeId);
            var findCandidate = await db.VotingCandidates.AnyAsync(c => c.id == request.candidateId);

            if (!findEmployee || !findCandidate)
            {
                return null;
            }

            var newVote = new VotingDetail
            {
                votingCandidateId = request.candidateId,
                employeeId = request.employeeId
            };

            await db.VotingDetails.AddAsync(newVote);
            await db.SaveChangesAsync();

            return newVote;
        }
    }
}
