namespace VoteApp.Queries
{
	public interface IQueryFactory
	{
		IQuery<TCriterion, TResult> Create<TCriterion, TResult>()
			where TCriterion : ICriterion;
	}
}