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
		[Route("{votingId:int}")]
        public IEnumerable<Option> Get(int votingId)
        {
            var items = queryBuilder.For<IEnumerable<Option>>().With(new QueryByVoting { VotingId = votingId });
            return items;
        }
        
        /*

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        } */
    }
}
