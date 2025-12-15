using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteHelperBot.AppService.Models
{
    public class ProcessMessageRequest
    {
        public required string UserId { get; set; } //(TODO): Burada mı olmalı headerdan falan mı almalıyım
        public required string Message { get; set; }
        public required string SessionId { get; set; }
        public required string Platform { get; set; } //()TODO): Web, Mobile, vs. gibi platform bilgisi. Enum olacak.

    }
}
