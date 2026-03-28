namespace EsemkaVote.API.Model
{
    public class VotingDetail
    {
        public int id { get; set; }
        public int votingCandidateId { get; set; }
        public int employeeId { get; set; }

        public VotingCandidate VotingCandidate { get; set; }
        public Employee Employee { get; set; }
    }
}
