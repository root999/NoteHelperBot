using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteHelperBot.Integration.LLM
{
    public interface ILLMClient
    {
        public Task<string> GetCompletionAsync(string prompt);
    }
}
