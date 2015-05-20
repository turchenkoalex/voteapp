using System.Linq;
using System.Collections.Generic;
using Microsoft.Framework.DependencyInjection;
using VoteApp.Models;

namespace VoteApp.Queries
{
    public static class RegisterQueriesExtension
    {
        public static void RegisterQueries(this IServiceCollection services)
        {
            services.AddTransient<IQueryFactory, QueryFactory>();
            services.AddTransient(typeof(IQueryFor<>), typeof(QueryFor<>));
            services.AddTransient<IQueryBuilder, QueryBuilder>();

            // queries
            
            services.AddTransient<IQuery<All, IEnumerable<Voting>>, VotingsQuery>();
            services.AddTransient<IQuery<ById, Voting>, VotingByIdQuery>();
            
            services.AddTransient<IQuery<All, IEnumerable<Option>>, OptionsQuery>();
            services.AddTransient<IQuery<ById, Option>, OptionByIdQuery>();
            services.AddTransient<IQuery<OptionsByVoting, IEnumerable<int>>, OptionIdsByVotingQuery>();
            services.AddTransient<IQuery<OptionsByVoting, IEnumerable<Option>>, OptionsByVotingQuery>();
        }
    }
}