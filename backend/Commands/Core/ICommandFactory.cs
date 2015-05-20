namespace VoteApp.Commands
{
	public interface ICommandFactory
	{
		ICommandHandler<TCommand> Create<TCommand>()
			where TCommand : ICommand;
	}
}