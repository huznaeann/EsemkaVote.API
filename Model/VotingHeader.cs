namespace EsemkaVote.API.Model
{
    public class VotingHeader
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateOnly startDate { get; set; }
        public DateOnly endDate { get; set; }


    }
}
