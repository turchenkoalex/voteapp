namespace VoteApp.Queries
{
	public class QueryBuilder : IQueryBuilder
	{
		private readonly IQueryFactory queryFactory;
		
		public QueryBuilder(IQueryFactory queryFactory)
		{
			this.queryFactory = queryFactory;
		}

		public IQueryFor<TResult> For<TResult>()
		{
			return new QueryFor<TResult>(queryFactory);
		}
	}
}