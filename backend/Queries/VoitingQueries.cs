using System.Linq;
using System.Collections.Generic;
using VoteApp.Models;
using VoteApp.Stores;

namespace VoteApp.Queries
{
    public class VotingsQuery : IQuery<All, IEnumerable<Voting>>
    {
        public IEnumerable<Voting> Ask(All criterion)
        {
            return Store.Votings;
        }
    }

    public class VotingByIdQuery : IQuery<ById, Voting>
    {
        public Voting Ask(ById criterion)
        {
            return Store.Votings.Single(x => x.Id == criterion.Id);
        }
    }
}