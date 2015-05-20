using System.Linq;
using System.Collections.Generic;
using VoteApp.Models;
using VoteApp.Stores;

namespace VoteApp.Queries
{
    public class VotingModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Active { get; set; }

        public IEnumerable<int> Options { get; set; }
    }

    public class VotingList
    {
        public IEnumerable<VotingModel> Votings { get; set; }

        public Meta Meta { get; set; }
    }

    public class VotingItem
    {
        public VotingModel Voting { get; set; }
    }

    public class VotingListQuery : IQuery<All, VotingList>
    {
        private readonly IQuery<ByVoting, IEnumerable<int>> optionsQuery;
        
        public VotingListQuery(IQuery<ByVoting, IEnumerable<int>> optionsQuery)
        {
            this.optionsQuery = optionsQuery;
        }
        
        public VotingList Ask(All criterion)
        {
            return new VotingList
            {
                Votings = Store.Votings.Select(x => new VotingModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Active = x.Active,
                    Options = optionsQuery.Ask(new ByVoting { VotingId = x.Id })
                }),
                Meta = new Meta
                {
                    Total = Store.Votings.Count
                }
            };
        }
    }

    public class VotingItemByIdQuery : IQuery<ById, VotingItem>
    {
        private readonly IQuery<ByVoting, IEnumerable<int>> optionsQuery;
        
        public VotingItemByIdQuery(IQuery<ByVoting, IEnumerable<int>> optionsQuery)
        {
            this.optionsQuery = optionsQuery;
        }
        
        public VotingItem Ask(ById criterion)
        {
            var item = Store.Votings.Single(x => x.Id == criterion.Id);
            return new VotingItem
            {
                Voting = new VotingModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Active = item.Active,
                    Options = optionsQuery.Ask(new ByVoting { VotingId = item.Id })
                }
            };
        }
    }
}