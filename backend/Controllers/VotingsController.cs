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
        
        [HttpGet]
        public VotingList Get()
        {
            var votings = queryBuilder.For<VotingList>().With(new All());
            return votings;
        }
        
        [HttpGet("{id}")]
        public VotingItem Get(int id)
        {
            var voting = queryBuilder.For<VotingItem>().With(new ById { Id = id });
            return voting;
        }
    }
}
