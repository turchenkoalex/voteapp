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
    
    public class OptionModel
    {
        public OptionModel()
        {
            
        }
        
        public OptionModel(Option option)
        {
            this.Id = option.Id;
            this.Title = option.Title;
            this.Voting = option.VotingId;
            this.VoteCount = option.VoteCount;
        }
        
        public int Id { get; set; }

        public string Title { get; set; }

        public int Voting { get; set; }

        public int VoteCount { get; set; }       
    }

    public class OptionItem
    {
        public OptionModel Option { get; set; }
    }
}