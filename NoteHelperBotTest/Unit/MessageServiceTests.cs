using NoteHelperBot.AppService.Impls;
using NoteHelperBot.AppService.Interfaces;
using NoteHelperBot.AppService.Models;

namespace NoteHelperBotTest.Unit
{
    public class MessageServiceTests
    {
        [Fact]
        public async Task Should_Return_Response_When_Message_Valid()
        {
            IMessageService messageService = new MessageService();

            var messageRequest = new ProcessMessageRequest
            {
                UserId = "test-user",
                Message = "Hello, this is a test message.",
                SessionId = "session-123",
                Platform = "Web"
            };
            var result = await messageService.ProcessMessageAsync(messageRequest);
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);

        }
    }
}
