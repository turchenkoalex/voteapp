namespace VoteApp.Models
{
    public class Option
    {
        public int Id { get; set; }

        public int VotingId { get; set; }

        public string Title { get; set; }

        public int VoteCount { get; set; }

        public void Vote()
        {
            this.VoteCount += 1;
        }
    }
}