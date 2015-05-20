using System;

namespace VoteApp.Queries
{
	public class QueryFactory : IQueryFactory
	{
		private readonly IServiceProvider serviceProvider;
		
		public QueryFactory(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}
		
		public IQuery<TCriterion, TResult> Create<TCriterion, TResult>()
			where TCriterion : ICriterion
		{
			var query = serviceProvider.GetService(typeof(IQuery<TCriterion, TResult>));
			return query as IQuery<TCriterion, TResult>;
		}
	} 
}