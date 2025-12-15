using NoteHelperBot.AppService.Models;

namespace NoteHelperBot.AppService.Interfaces
{
    public interface IMessageService
    {
        public Task<ProcessMessageResponse> ProcessMessageAsync(ProcessMessageRequest message);
    }
}
