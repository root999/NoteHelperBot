using Moq;
using NoteHelperBot.AppService.Impls;

namespace NoteHelperBotTest.Unit.AppService
{
    public class IntentServiceTests
    {
        [Fact]

        public async Task Should_Detect_Save_Intent() {

            var mockLLMClient = new Moq.Mock<NoteHelperBot.Integration.LLM.ILLMClient>();
            mockLLMClient.Setup(x => x.GetCompletionAsync(Moq.It.IsAny<string>()))
                .ReturnsAsync("Save");
            var intentService = new IntentService(mockLLMClient.Object);

            var intent = await intentService.DetermineIntentAsync("Please save this note for me.");

            Assert.Equal("Save", intent);
        }
    }
}
