using Microsoft.Extensions.Logging;
using NoteHelperBot.AppService.Interfaces;
using NoteHelperBot.AppService.Models;
using NoteHelperBot.Infrastructure.Repositories;

namespace NoteHelperBot.AppService.Impls
{
    public class MessageService : IMessageService
    {
        private readonly INoteRepository noteRepository;
        private readonly ILogger<MessageService> logger;
        private readonly IIntentService intentService;

        public MessageService(INoteRepository noteRepository, IIntentService intentService, ILogger<MessageService> logger)
        {
            this.noteRepository = noteRepository;
            this.intentService = intentService;
            this.logger = logger;
        }


        public async Task<ProcessMessageResponse> ProcessMessageAsync(ProcessMessageRequest message)
        {
            logger.LogInformation("Processing message from User: {UserId}, Session: {SessionId}", message.UserId, message.SessionId);
            
            var intent = await intentService.DetermineIntentAsync(message.Message);
            try
            {
                switch (intent)
                {
                    case "Save":
                        await noteRepository.SaveMessageAsync(new Infrastructure.Models.MessageRecord
                        {
                            UserId = message.UserId,
                            Message = message.Message,
                            SessionId = message.SessionId,
                            Platform = message.Platform
                        });
                        logger.LogInformation("Message saved for User: {UserId}, Session: {SessionId}", message.UserId, message.SessionId);
                        return new ProcessMessageResponse
                        {
                            IsSuccess = true,
                            ResponseMessage = "Your message has been saved.",
                            Intent = intent,
                            ProcessedAt = DateTime.UtcNow
                        };
                    default:
                        logger.LogInformation("Unhandled intent '{Intent}' for User: {UserId}, Session: {SessionId}", intent, message.UserId, message.SessionId);
                        throw new Exception("Unhandled intent");

                }
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error processing message for User: {UserId}, Session: {SessionId}", message.UserId, message.SessionId);
                return new ProcessMessageResponse
                {
                    IsSuccess = false,
                    ResponseMessage = "An error occurred while processing your message.",
                    Intent = intent,
                    ProcessedAt = DateTime.UtcNow
                };
            }


        }
    }
}
