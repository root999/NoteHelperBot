using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteHelperBot.AppService.Models
{
    public class ProcessMessageResponse
    {
        public bool IsSuccess { get; set; }
        public string? ResponseMessage { get; set; }
        public string? Intent { get; set; } //(TODO:)Testing için kullanılacak. create,search,help,chat,organize,plan gibi kullanıcının yapmak istediği işlem.
        public DateTime ProcessedAt { get; set; } = DateTime.UtcNow;

        //public object AdditionalData { get; set; } //(TODO:) İleride ek bilgi taşımak için kullanılabilir.


    }
}
