using Microsoft.Data.Entity;

namespace VoteApp.Tests
{
    public class TestDbContext : DAL.ApplicationDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryStore(true);
        }
    }
}