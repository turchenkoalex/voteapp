using System.Linq;
using Xunit;

namespace VoteApp.Tests
{
    public class VoteByIdHandlerTest
    {
        [Fact]
        public void CommandCanExecute()
        {
            var context = new TestDbContext();
            context.Options.Add(
                new VoteApp.DAL.Option
                {
                    Id = 999,
                    VoteCount = 10
                });
            context.SaveChanges();

            var handler = new VoteApp.Commands.VoteByIdHandler(context);
            var command = new VoteApp.Commands.VoteById() { Id = 999 };
            handler.Execute(command);
            
            var expected = 11;
            var actual = context.Options.AsNoTracking().First(x => x.Id == 999).VoteCount;
            Assert.Equal(expected, actual);
        }
    }
}