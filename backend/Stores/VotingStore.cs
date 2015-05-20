using System.Collections.Generic;
using VoteApp.Models;

namespace VoteApp.Stores
{
	public static partial class Store
	{
		static Store()
		{
			Votings = new List<Voting> {
				new Voting
				{
					Id = 1,
					Title = "Vote number 1",
					Active = true,
					Options = {
						new Option 
						{
							Id = 1,
							Title = "Option 1"
						},
						new Option
						{
							Id = 2,
							Title = "Option 2"
						}
					}
				}
			};
		}
		
		public static List<Voting> Votings { get; private set; }
	}
}