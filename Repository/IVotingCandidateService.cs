using EsemkaVote.API.Model;
using EsemkaVote.API.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EsemkaVote.API.Repository
{
    public interface IVotingCandidateService
    {
        Task<VotingDetail?> VoteCandidateAsync(VoteCandidateRequest request);
        Task<List<CandidatesResponse>> GetAllCandidatesAsync(int votingHeaderId); 
    }
}
