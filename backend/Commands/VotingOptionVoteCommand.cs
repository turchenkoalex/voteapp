using System.Linq;
using VoteApp.Stores;

namespace VoteApp.Commands
{
    public class VotingOptionVote : ICommand
    {
        public int VotingId { get; set; }
        
		public int OptionId { get; set; }
    }

    public class VotingOptionVoteHandler : ICommandHandler<VotingOptionVote>
    {
        public void Execute(VotingOptionVote command)
        {
			var voting = Store.Votings.Single(x => x.Id == command.VotingId);
			var option = voting.Options.Single(x => x.Id == command.OptionId);
			option.Vote();
        }
    }
}