using System.Linq;
using Xunit;
using Moq;
using Microsoft.Framework.Logging;

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

            var logger = Mock.Of<ILogger>();
            var loggerFactory = Mock.Of<ILoggerFactory>(f => f.CreateLogger(It.IsAny<string>()) == logger);

            var handler = new VoteApp.Commands.VoteByIdHandler(context, loggerFactory);
            var command = new VoteApp.Commands.VoteById() { Id = 999 };
            handler.Execute(command);
            
            var expected = 11;
            var actual = context.Options.AsNoTracking().First(x => x.Id == 999).VoteCount;
            Assert.Equal(expected, actual);
        }
    }
}