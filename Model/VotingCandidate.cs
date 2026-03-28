namespace EsemkaVote.API.Model
{
    public class VotingCandidate
    {
        public int id { get; set; }
        public int votingHeaderId { get; set; }
        public int employeeId { get; set; }

        public VotingHeader VotingHeader { get; set; }
        public Employee Employee { get; set; }

        
    }
}
