using System.Linq;
using System.Collections.Generic;
using VoteApp.Models;
using VoteApp.Stores;

namespace VoteApp.Queries
{
    public class ByVoting : ICriterion
    {
        public int VotingId { get; set; }
    }

    public class OptionModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Voting { get; set; }

        public int VoteCount { get; set; }
    }

    public class OptionItem
    {
        public OptionModel Option { get; set; }
    }

    public class OptionIdsByVotingQuery : IQuery<ByVoting, IEnumerable<int>>
    {
        public IEnumerable<int> Ask(ByVoting criterion)
        {
            return Store.Options
                .Where(x => x.VotingId == criterion.VotingId)
                .Select(x => x.Id);
        }
    }

    public class OptionItemByIdQuery : IQuery<ById, OptionItem>
    {
        public OptionItem Ask(ById criterion)
        {
            var item = Store.Options.Single(x => x.Id == criterion.Id);

            return new OptionItem
            {
                Option = new OptionModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Voting = item.VotingId,
                    VoteCount = item.VoteCount
                }
            };
        }
    }

}