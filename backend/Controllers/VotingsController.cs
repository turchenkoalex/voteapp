using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using VoteApp.Queries;
using VoteApp.Commands;
using VoteApp.Models;

namespace VoteApp.Controllers
{
    [Route("api/[controller]")]
    public class VotingsController : Controller
    {        
        private readonly IQueryBuilder queryBuilder;
        
        private readonly ICommandBuilder commandBuilder;
        
        public VotingsController(IQueryBuilder queryBuilder, ICommandBuilder commandBuilder)
        {
            this.queryBuilder = queryBuilder;
            this.commandBuilder = commandBuilder;
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
        public VotingItem Get(int id)
        {
            var voting = queryBuilder.For<Voting>().With(new ById { Id = id });
            var options = queryBuilder.For<IEnumerable<Option>>().With(new OptionsByVoting { VotingId = id });
            return new VotingItem
            {
                Voting = ToVotingModel(voting),
                Options = options.Select(ToOptionModel)
            };
        }
    }
}
