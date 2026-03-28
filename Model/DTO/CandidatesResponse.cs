using System.Security.Principal;

namespace EsemkaVote.API.Model.DTO
{
    public class CandidatesResponse
    {
        public int candidateId { get; set; }
        public string name { get; set; }
        public string division { get; set; }
        public string photo { get; set; }
    }
}
