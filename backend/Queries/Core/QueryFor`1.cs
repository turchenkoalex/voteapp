namespace VoteApp.Queries
{
    public class QueryFor<TResult> : IQueryFor<TResult>
    {
        private readonly IQueryFactory queryFactory;

        public QueryFor(IQueryFactory queryFactory)
        {
            this.queryFactory = queryFactory;
        }

        public TResult With<TCriterion>(TCriterion criterion)
            where TCriterion : ICriterion
        {
            var query = queryFactory.Create<TCriterion, TResult>();
            return query.Ask(criterion);
        }
    }
}
