using NoteHelperBot.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteHelperBot.Infrastructure.Repositories
{
    public interface INoteRepository
    {
        public Task SaveMessageAsync(MessageRecord messageRecord);


    }
}
