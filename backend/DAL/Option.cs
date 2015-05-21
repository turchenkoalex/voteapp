namespace VoteApp.DAL
{
    public class Option
    {
        public int Id { get; set; }

        public int VotingId { get; set; }

        public string Title { get; set; }

        public int VoteCount { get; set; }
    }
}