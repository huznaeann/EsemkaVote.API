using EsemkaVote.API.Model.DTO;

namespace EsemkaVote.API.Repository
{
    public interface IVotingHeaderService
    {
        Task<List<VotingHeaderResponse>?> GetAllVoteEvents();
    }
}
