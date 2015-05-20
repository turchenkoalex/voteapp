using System.Linq;
using System.Collections.Generic;
using VoteApp.Models;
using VoteApp.Stores;

namespace VoteApp.Queries
{
    public class QueryByVoting : ICriterion
    {
        public int VotingId { get; set; }
    }
	
	public class OptionsQueryByVoting : IQuery<QueryByVoting, IEnumerable<Option>>
	{
		public IEnumerable<Option> Ask(QueryByVoting criterion)
		{
			var voting = Store.Votings.Single(x => x.Id == criterion.VotingId);
			return voting.Options;
		}
	} 
}