using NoteHelperBot.AppService.Interfaces;
using NoteHelperBot.AppService.Models;

namespace NoteHelperBot.AppService.Impls
{
    public class MessageService : IMessageService
    {
        public async Task<ProcessMessageResponse> ProcessMessageAsync(ProcessMessageRequest message)
        {
            return new ProcessMessageResponse
            {
                IsSuccess = true,
                ResponseMessage = $"Received your message: {message.Message}",
                Intent = "GeneralInquiry",
                ProcessedAt = DateTime.UtcNow
            };
        }
    }
}
