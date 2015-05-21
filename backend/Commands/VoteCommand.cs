using System.Linq;
using VoteApp.DAL;

namespace VoteApp.Commands
{
    public class VoteById : ICommand
    {
		public int Id { get; set; }
    }

    public class VoteByIdHandler : ICommandHandler<VoteById>
    {
        private readonly ApplicationDbContext context;

        public VoteByIdHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Execute(VoteById command)
        {
            var option = context.Options.Single(x => x.Id == command.Id);
            option.VoteCount += 1;
            context.SaveChanges();
        }
    }
}