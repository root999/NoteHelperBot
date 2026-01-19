using Microsoft.EntityFrameworkCore;
using NoteHelperBot.Infrastructure;
using NoteHelperBot.Infrastructure.Models;
using NoteHelperBot.Infrastructure.Repositories;

namespace NoteHelperBotTest.Unit.Infrastructure
{
    public class NoteRepositoryTests
    {
        [Fact]
        public async Task Should_Save_Message_To_Db()
        {

            var options = new DbContextOptionsBuilder<MessageRecordDbContext>()
                  .UseInMemoryDatabase(databaseName: "NoteRepositoryTests_SaveMessage")
                  .Options;

            using (var context = new MessageRecordDbContext(options))
            {
                var repo = new NoteRepository(context);

                var message = new MessageRecord
                {
                    UserId = "test-user",
                    Message = "Test message",
                    SessionId = "session-1",
                    Platform = "Web"
                };

                await repo.SaveMessageAsync(message);
            }

            using (var context = new MessageRecordDbContext(options))
            {
                var saved = await context.Messages.SingleOrDefaultAsync(m => m.UserId == "test-user" && m.Message == "Test message");
                Assert.NotNull(saved);
                Assert.Equal("session-1", saved.SessionId);
                Assert.Equal("Web", saved.Platform);
            }

        }
    }
}
