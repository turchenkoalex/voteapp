using System.Linq;
using VoteApp.DAL;
using Microsoft.Framework.Logging;

namespace VoteApp.Commands
{
    public class VoteById : ICommand
    {
        public int Id { get; set; }
    }

    public class CreateOption : ICommand
    {
        public string Title { get; set; }

        public int VotingId { get; set; }

        public int GeneratedId { get; set; }
    }

    public class UpdateOption : ICommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class OptionCommandsHandler :
        ICommandHandler<VoteById>,
        ICommandHandler<CreateOption>,
        ICommandHandler<UpdateOption>
    {
        private readonly ApplicationDbContext context;

        private readonly ILoggerFactory loggerFactory;

        public OptionCommandsHandler(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            this.context = context;
            this.loggerFactory = loggerFactory;
        }

        public void Execute(VoteById command)
        {
            var option = context.Options.Single(x => x.Id == command.Id);
            option.VoteCount += 1;
            var i = context.SaveChanges();
        }

        public void Execute(CreateOption command)
        {
            var option = new Option
            {
                Title = command.Title,
                VotingId = command.VotingId,
                VoteCount = 0
            };

            context.Options.Add(option);
            context.SaveChanges();
            command.GeneratedId = option.Id;
        }

        public void Execute(UpdateOption command)
        {
            var option = context.Options.First(x => x.Id == command.Id);
            option.Title = command.Title;
            context.SaveChanges();
        }
    }
}