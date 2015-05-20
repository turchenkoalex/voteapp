namespace VoteApp.Commands
{
	public interface ICommandBuilder
	{
		void Execute<TCommand>(TCommand command)
			where TCommand : ICommand;
	}
}