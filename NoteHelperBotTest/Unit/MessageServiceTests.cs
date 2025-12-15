using NoteHelperBotTest.ControllerTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NoteHelperBotTest.Unit
{
    public class MessageServiceTests
    {
        [Fact]
        public async Task Should_Return_AI_Response_When_Message_Valid()
        {
           IMessageService messageService = new MessageService();

            var messageRequest = new MessageRequest
            {
                Text = "Hello, this is a test message."
            };
            var result = await messageService.ProcessMessageAsync(messageRequest);
            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.MessageId));

        }
    }
}
