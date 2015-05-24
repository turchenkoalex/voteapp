namespace VoteApp.Commands
{
	public class CommandBuilder : ICommandBuilder
	{
		private readonly ICommandFactory commandFactory;
		
		public CommandBuilder(ICommandFactory commandFactory)
		{
			this.commandFactory = commandFactory;
		}
		
		public void Execute<TCommand>(TCommand command)
			where TCommand : ICommand
		{
			var commandHandler = commandFactory.Create<TCommand>();
            if (commandHandler == null)
            {
                throw new System.ArgumentNullException("CommandHandler", $"CommandHandler for {typeof(TCommand).FullName} not found.");
            }
			commandHandler.Execute(command);
		}
	}
}