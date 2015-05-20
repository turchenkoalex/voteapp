using System.Collections.Generic;

namespace VoteApp.Models
{
    public class Voting
    {
        public Voting()
        {
            Options = new List<Option>();
        }
        
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Active { get; set; }

        public ICollection<Option> Options { get; set; }
    }
}