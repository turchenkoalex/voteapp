using System.Collections.Generic;
using VoteApp.Models;
using VoteApp.Stores;

namespace VoteApp.Queries
{
	public class VotingQueryAll : IQuery<QueryAll, IEnumerable<Voting>> 
	{
		public IEnumerable<Voting> Ask(QueryAll criterion)
		{
			return Store.Votings;
		}
	}
}