using System.Linq;
using System.Collections.Generic;
using VoteApp.DAL;

namespace VoteApp.Queries
{
    public class VotingsQuery : IQuery<All, IEnumerable<Voting>>
    {
        private ApplicationDbContext context;

        public VotingsQuery(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Voting> Ask(All criterion)
        {
            return context.Votings.AsNoTracking().ToList();
        }
    }

    public class VotingByIdQuery : IQuery<ById, Voting>
    {
        private ApplicationDbContext context;

        public VotingByIdQuery(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Voting Ask(ById criterion)
        {
            return context.Votings.AsNoTracking().FirstOrDefault(x => x.Id == criterion.Id);
        }
    }
}