using System.Linq;
using System.Collections.Generic;
using VoteApp.Models;
using VoteApp.Stores;

namespace VoteApp.Queries
{
    public class OptionsByVoting : ICriterion
    {
        public int VotingId { get; set; }
    }

    public class OptionIdsByVotingQuery : IQuery<OptionsByVoting, IEnumerable<int>>
    {
        public IEnumerable<int> Ask(OptionsByVoting criterion)
        {
            return Store.Options
                .Where(x => x.VotingId == criterion.VotingId)
                .Select(x => x.Id);
        }
    }
    
    public class OptionsByVotingQuery : IQuery<OptionsByVoting, IEnumerable<Option>>
    {
        public IEnumerable<Option> Ask(OptionsByVoting criterion)
        {
            return Store.Options
                .Where(x => x.VotingId == criterion.VotingId);
        }
    }
    
    public class OptionsQuery : IQuery<All, IEnumerable<Option>>
    {
        public IEnumerable<Option> Ask(All criterion)
        {
            return Store.Options;
        }
    }

    public class OptionByIdQuery : IQuery<ById, Option>
    {
        public Option Ask(ById criterion)
        {
            return Store.Options.Single(x => x.Id == criterion.Id);
        }
    }

}