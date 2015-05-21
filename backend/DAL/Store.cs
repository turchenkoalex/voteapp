using System.Collections.Generic;

namespace VoteApp.DAL
{
    public static class InitialStore
    {
        public static List<Voting> Votings
        {
            get
            {
                return new List<Voting>
                {
                    new Voting
                    {
                        Id = 1,
                        Title = "Голосование № 1",
                        Active = true
                    },
                    new Voting
                    {
                        Id = 2,
                        Title = "Голосование № 2",
                        Active = true
                    }
                };
            }
        }

        public static List<Option> Options
        {
            get
            {
                return new List<Option>
	            {
	                new Option
	                {
	                    Id = 1,
	                    VotingId = 1,
	                    Title = "Option 1",
	                    VoteCount = 0
	                },
	                new Option
	                {
	                    Id = 2,
	                    VotingId = 1,
	                    Title = "Option 2",
	                    VoteCount = 0
	                },
	                new Option
	                {
	                    Id = 3,
	                    VotingId = 2,
	                    Title = "Option 3",
	                    VoteCount = 0
	                },
	                new Option
	                {
	                    Id = 4,
	                    VotingId = 2,
	                    Title = "Option 4",
	                    VoteCount = 0
	                }
	            };
            }
        }
    }
}