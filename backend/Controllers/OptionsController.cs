using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using VoteApp.Queries;
using VoteApp.Commands;
using VoteApp.Models;

namespace VoteApp.Controllers
{
    [Route("api/[controller]")]
    public class OptionsController : Controller
    {        
        private readonly IQueryBuilder queryBuilder;
        
        private readonly ICommandBuilder commandBuilder;
        
        public OptionsController(IQueryBuilder queryBuilder, ICommandBuilder commandBuilder)
        {
            this.queryBuilder = queryBuilder;
            this.commandBuilder = commandBuilder;
        }
        
        // GET: api/values
        [HttpGet]
		[Route("{id}")]
        public OptionItem Get(int id)
        {
            var item = queryBuilder.For<OptionItem>().With(new ById { Id = id });
            return item;
        }
        
        [HttpPost]
        [Route("{id}/vote")]
        public void Vote(int id)
        {
            commandBuilder.Execute(new VoteById { Id = id });
        }
    }
}
