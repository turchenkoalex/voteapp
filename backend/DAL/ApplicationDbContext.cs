using Microsoft.Data.Entity;

namespace VoteApp.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Voting> Votings { get; set; }

        public DbSet<Option> Options { get; set; }
    }
}