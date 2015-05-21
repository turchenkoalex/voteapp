using VoteApp.DAL;
using System.Collections.Generic;

namespace VoteApp.Models
{
    public class VotingModel
    {
        public VotingModel()
        {

        }

        public VotingModel(Voting voting, IEnumerable<int> options)
        {
            this.Id = voting.Id;
            this.Title = voting.Title;
            this.Active = voting.Active;
            this.Options = options;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public bool Active { get; set; }

        public IEnumerable<int> Options { get; set; }
    }

    public class VotingList
    {
        public IEnumerable<VotingModel> Votings { get; set; }

        public IEnumerable<OptionModel> Options { get; set; }

        public Meta Meta { get; set; }
    }

    public class VotingItem
    {
        public VotingModel Voting { get; set; }

        public IEnumerable<OptionModel> Options { get; set; }
    }
}