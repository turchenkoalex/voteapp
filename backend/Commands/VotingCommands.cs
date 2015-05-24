using System.Linq;
using VoteApp.DAL;
using Microsoft.Framework.Logging;

namespace VoteApp.Commands
{
    public class CreateVoting : ICommand
    {
        public string Title { get; set; }

        public bool Active { get; set; }

        public int GeneratedId { get; set; }
    }

    public class UpdateVoting : ICommand
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Active { get; set; }
    }

    public class VortingCommandsHandler :
        ICommandHandler<CreateVoting>,
        ICommandHandler<UpdateVoting>
    {
        private readonly ApplicationDbContext context;

        public VortingCommandsHandler(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            this.context = context;
        }

        public void Execute(CreateVoting command)
        {
            var item = new Voting
            {
                Title = command.Title,
                Active = command.Active
            };

            context.Votings.Add(item);
            context.SaveChanges();
            command.GeneratedId = item.Id;
        }

        public void Execute(UpdateVoting command)
        {
            var option = context.Votings.First(x => x.Id == command.Id);
            option.Title = command.Title;
            option.Active = command.Active;
            context.SaveChanges();
        }
    }
}