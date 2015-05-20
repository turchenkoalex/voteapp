using System;

namespace VoteApp.Commands
{
	public class CommandFactory : ICommandFactory
	{
		private readonly IServiceProvider serviceProvider;
		
		public CommandFactory(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}
		
		public ICommandHandler<TCommand> Create<TCommand>()
			where TCommand : ICommand
		{
			var commandHandler = serviceProvider.GetService(typeof(ICommandHandler<TCommand>));
			return commandHandler as ICommandHandler<TCommand>;
		}
	}
}