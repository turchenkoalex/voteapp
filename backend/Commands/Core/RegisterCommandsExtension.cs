using Microsoft.Framework.DependencyInjection;

namespace VoteApp.Commands
{
	public static class RegisterCommandsExtension
	{
		public static void RegisterCommands(this IServiceCollection services)
		{
			services.AddTransient<ICommandFactory, CommandFactory>();
			services.AddTransient<ICommandBuilder, CommandBuilder>();
			
			// commands
            services.AddTransient<ICommandHandler<VotingOptionVote>, VotingOptionVoteHandler>();
		}
	}
}