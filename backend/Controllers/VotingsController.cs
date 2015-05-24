using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using VoteApp.Queries;
using VoteApp.Commands;
using VoteApp.Models;
using VoteApp.DAL;
using Microsoft.AspNet.WebUtilities;

namespace VoteApp.Controllers
{
    [Route("api/[controller]")]
    public class VotingsController : Controller
    {
        private readonly IQueryBuilder queryBuilder;
        
        private readonly ICommandBuilder commandBuilder;
        
        private readonly ApplicationDbContext context;

        public VotingsController(IQueryBuilder queryBuilder, ICommandBuilder commandBuilder, ApplicationDbContext context)
        {
            this.queryBuilder = queryBuilder;
            this.commandBuilder = commandBuilder;
            this.context = context;
        }

        private VotingModel ToVotingModel(Voting voting)
        {
            var optionIds = queryBuilder.For<IEnumerable<int>>().With(new OptionsByVoting { VotingId = voting.Id });
            return new VotingModel(voting, optionIds);
        }

        private OptionModel ToOptionModel(Option option)
        {
            return new OptionModel(option);
        }
        
        [HttpGet]
        public VotingList Get()
        {
            var votings = queryBuilder.For<IEnumerable<Voting>>().With(new All());
            var options = queryBuilder.For<IEnumerable<Option>>().With(new All());

            return new VotingList
            {
                  Votings = votings.Select(ToVotingModel),
                  Options = options.Select(ToOptionModel),
                  Meta = new Meta 
                  { 
                      Total = votings.Count()
                  }
            };
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var voting = queryBuilder.For<Voting>().With(new ById { Id = id });
            if (voting == null)
            {
                return HttpNotFound();
            }
            var options = queryBuilder.For<IEnumerable<Option>>().With(new OptionsByVoting { VotingId = id });
            return Json(new VotingItem
            {
                Voting = ToVotingModel(voting),
                Options = options.Select(ToOptionModel)
            });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody]VotingItem item)
        {
            commandBuilder.Execute(
                new UpdateVoting
                {
                    Id = id,
                    Title = item.Voting.Title,
                    Active = item.Voting.Active
                });
            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        [HttpPost]
        public IActionResult Post([FromBody]VotingItem item)
        {
            var command =
                new CreateVoting
                {
                    Title = item.Voting.Title,
                    Active = item.Voting.Active
                };
            commandBuilder.Execute(command);
            item.Voting.Id = command.GeneratedId;
            return new CreatedAtRouteResult(new { id = command.GeneratedId }, item);
        }
    }
}
