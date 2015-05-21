using System.Linq;
using System.Collections.Generic;
using VoteApp.DAL;

namespace VoteApp.Queries
{
    public class OptionsByVoting : ICriterion
    {
        public int VotingId { get; set; }
    }

    public class OptionIdsByVotingQuery : IQuery<OptionsByVoting, IEnumerable<int>>
    {
        private readonly ApplicationDbContext context;

        public OptionIdsByVotingQuery(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<int> Ask(OptionsByVoting criterion)
        {
            return context.Options.AsNoTracking()
                .Where(x => x.VotingId == criterion.VotingId)
                .Select(x => x.Id);
        }
    }
    
    public class OptionsByVotingQuery : IQuery<OptionsByVoting, IEnumerable<Option>>
    {
        private readonly ApplicationDbContext context;

        public OptionsByVotingQuery(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Option> Ask(OptionsByVoting criterion)
        {
            return context.Options.AsNoTracking()
                .Where(x => x.VotingId == criterion.VotingId);
        }
    }
    
    public class OptionsQuery : IQuery<All, IEnumerable<Option>>
    {
        private readonly ApplicationDbContext context;

        public OptionsQuery(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Option> Ask(All criterion)
        {
            return context.Options.AsNoTracking();
        }
    }

    public class OptionByIdQuery : IQuery<ById, Option>
    {
        private readonly ApplicationDbContext context;

        public OptionByIdQuery(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Option Ask(ById criterion)
        {
            return context.Options.AsNoTracking().Single(x => x.Id == criterion.Id);
        }
    }
}