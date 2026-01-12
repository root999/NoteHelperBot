using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteHelperBotTest.Integration
{
    public class GeminiClientIntegrationTest
    {
        [Fact]
        public async Task Test_GeminiClient_Integration()
        {

            var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.secret.json", optional: false, reloadOnChange: true)
             .AddEnvironmentVariables()
             .Build();

            var geminiClient = new NoteHelperBot.Integration.LLM.GeminiClient( configuration);

            var prompt = "What is the capital of France?";
            var response = await geminiClient.GetCompletionAsync(prompt);
            Assert.True(true); // Placeholder assertion
        }
    }
}
