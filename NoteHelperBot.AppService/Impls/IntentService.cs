using NoteHelperBot.AppService.Interfaces;
using NoteHelperBot.Integration.LLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteHelperBot.AppService.Impls
{
    public class IntentService : IIntentService
    {
        private readonly ILLMClient languageModelClient;

        public IntentService(ILLMClient languageModelClient)
        {
            this.languageModelClient = languageModelClient;
        }

        public async Task<string> DetermineIntentAsync(string message)
        {
            return await languageModelClient.GetCompletionAsync($"Determine the intent of the following message: {message}");
        }
    }
}
