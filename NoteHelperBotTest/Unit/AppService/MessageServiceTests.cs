using Microsoft.Extensions.Logging;
using Moq;
using NoteHelperBot.AppService.Impls;
using NoteHelperBot.AppService.Interfaces;
using NoteHelperBot.AppService.Models;
using NoteHelperBot.Infrastructure.Models;
using NoteHelperBot.Infrastructure.Repositories;

namespace NoteHelperBotTest.Unit.AppService
{
    public class MessageServiceTests
    {
        [Fact]
        public async Task Should_Return_Response_When_Message_Valid()
        {

            var repoMock = new Mock<INoteRepository>();
            var intentDetectorMock = new Mock<IIntentService>();
            var loggerMock = new Mock<ILogger<MessageService>>();

            IMessageService messageService = new MessageService(repoMock.Object, intentDetectorMock.Object, loggerMock.Object);

            var messageRequest = new ProcessMessageRequest
            {
                UserId = "test-user",
                Message = "Hello, this is a test message.",
                SessionId = "session-123",
                Platform = "Web"
            };
            var result = await messageService.ProcessMessageAsync(messageRequest);
            Assert.NotNull(result);
            //Assert.True(result.IsSuccess); // Her zaman true dönmek zorunda değil ama bir response dönmeli

        }

        [Fact]
        public async Task Should_Save_Message()
        {

            var repoMock = new Mock<INoteRepository>();
            var intentDetectorMock = new Mock<IIntentService>();
            var loggerMock = new Mock<ILogger<MessageService>>();


            intentDetectorMock.Setup(x => x.DetermineIntentAsync(It.IsAny<string>()))
                .ReturnsAsync("Save");

            IMessageService messageService = new MessageService(repoMock.Object,intentDetectorMock.Object,loggerMock.Object);

            var messageRequest = new ProcessMessageRequest
            {
                UserId = "test-user",
                Message = "Hello, this is a test message.",
                SessionId = "session-123",
                Platform = "Web"
            };
            var result = await messageService.ProcessMessageAsync(messageRequest);

            Assert.True(result.IsSuccess);
            repoMock.Verify(x => x.SaveMessageAsync(It.IsAny<MessageRecord>()), Times.Once);

        }
    }
}
