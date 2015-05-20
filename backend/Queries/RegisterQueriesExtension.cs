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
            services.AddTransient<IQuery<All, VotingList>, VotingListQuery>();
            services.AddTransient<IQuery<ById, VotingItem>, VotingItemByIdQuery>();
            services.AddTransient<IQuery<ByVoting, IEnumerable<int>>, OptionIdsByVotingQuery>();
            services.AddTransient<IQuery<ById, OptionItem>, OptionItemByIdQuery>();
        }
    }
}