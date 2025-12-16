using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteHelperBot.AppService.Interfaces
{
    public interface IIntentService
    {
        public Task<string> DetermineIntentAsync(string message);
    }
}
