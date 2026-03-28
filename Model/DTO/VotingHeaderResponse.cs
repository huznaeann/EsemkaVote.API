namespace EsemkaVote.API.Model.DTO
{
    public class VotingHeaderResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateOnly startDate { get; set; }
        public DateOnly endDate { get; set; }
        public int voters { get; set; }
    }
}
