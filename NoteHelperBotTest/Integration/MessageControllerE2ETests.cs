using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace NoteHelperBotTest.ControllerTests
{
    public class MessageControllerE2ETests
    {
        [Fact]
        public async Task CanAcceptTextMessagesAndReturnsResponse()
        {
            using var factory = new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<global::NoteHelperBot.Program>();

            var client = factory.CreateClient();

            var request = new { Text = "hello world" };
            var response = await client.PostAsJsonAsync("/api/message", request);

            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadFromJsonAsync<MessageReply>();

            Assert.NotNull(body);
            Assert.Equal("Received: hello world", body.Reply);
        }
    }

    public class MessageReply
    {
        public string? Reply { get; set; }
    }
}
