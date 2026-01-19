using Google.GenAI;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace NoteHelperBot.Integration.LLM
{
    public class GeminiClient : ILLMClient
    {
        private readonly IConfiguration configuration;

        public GeminiClient(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<string> GetCompletionAsync(string prompt)
        {
            try
            {
                var client = new Client(apiKey:configuration["GOOGLE_API_KEY"]);
                var response = await client.Models.GenerateContentAsync(
                  model: "gemini-2.5-flash", contents: "Explain how AI works in a few words"
                );

            }
            catch(Exception ex)
            {
                throw new Exception("Error calling Gemini API", ex);
            }
            return null;
        }
    }
}
