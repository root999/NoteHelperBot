using NoteHelperBot.AppService.Interfaces;
using NoteHelperBot.AppService.Models;

namespace NoteHelperBot.AppService.Impls
{
    public class MessageService : IMessageService
    {
        public Task<ProcessMessageResponse> ProcessMessageAsync(ProcessMessageRequest message)
        {
            throw new NotImplementedException();
        }
    }
}
