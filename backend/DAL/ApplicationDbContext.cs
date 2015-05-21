using Microsoft.Data.Entity;

namespace VoteApp.DAL
{
    public class ApplicationDbContext : DbContext
    {
        private static bool created = false;

        public ApplicationDbContext() : base()
        {
            if (!created)
            {
                created = true;
                Votings.AddRange(InitialStore.Votings);
                Options.AddRange(InitialStore.Options);
                SaveChanges();
            }
        }

        public DbSet<Voting> Votings { get; set; }

        public DbSet<Option> Options { get; set; }
    }
}