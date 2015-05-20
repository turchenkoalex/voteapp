namespace VoteApp.Queries
{
	public interface IQueryBuilder
	{
		IQueryFor<TResult> For<TResult>();
	}
}