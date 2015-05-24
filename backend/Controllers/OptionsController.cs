using Microsoft.AspNet.Mvc;
using VoteApp.Queries;
using VoteApp.Commands;
using VoteApp.Models;
using VoteApp.DAL;
using Microsoft.Framework.Logging;
using Microsoft.AspNet.WebUtilities;

namespace VoteApp.Controllers
{
    [Route("api/[controller]")]
    public class OptionsController : Controller
    {        
        private readonly IQueryBuilder queryBuilder;
        
        private readonly ICommandBuilder commandBuilder;

        private readonly ILoggerFactory loggerFactory;

        public OptionsController(IQueryBuilder queryBuilder,
            ICommandBuilder commandBuilder,
            ILoggerFactory loggerFactory)
        {
            this.queryBuilder = queryBuilder;
            this.commandBuilder = commandBuilder;
            this.loggerFactory = loggerFactory;
        }
        
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var option = queryBuilder.For<Option>().With(new ById { Id = id });
            if (option == null)
            {
                return HttpNotFound();
            }
            return Json(new OptionItem
            {
                Option = new OptionModel(option)
            });
        }

        [HttpPost]
        [Route("{id}/vote")]
        public void Vote(int id)
        {
            commandBuilder.Execute(new VoteById { Id = id });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody]OptionItem optionItem)
        {
            commandBuilder.Execute(
                new UpdateOption
                {
                    Id = id,
                    Title = optionItem.Option.Title
                });
            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        [HttpPost]
        public IActionResult Post([FromBody]OptionItem optionItem)
        {
            var command =
                new CreateOption
                {
                    Title = optionItem.Option.Title,
                    VotingId = optionItem.Option.Voting
                };
            commandBuilder.Execute(command);
            optionItem.Option.Id = command.GeneratedId;
            return new CreatedAtRouteResult(new { id = command.GeneratedId }, optionItem);
        }
    }
}
