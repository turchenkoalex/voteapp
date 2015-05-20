using System.Linq;
using VoteApp.Stores;

namespace VoteApp.Commands
{
    public class VoteById : ICommand
    {
		public int Id { get; set; }
    }

    public class VoteByIdHandler : ICommandHandler<VoteById>
    {
        public void Execute(VoteById command)
        {
			var option = Store.Options.Single(x => x.Id == command.Id);
			option.Vote();
        }
    }
}