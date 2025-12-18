using NoteHelperBot.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteHelperBot.Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {

        private readonly MessageRecordDbContext _context;    

        public NoteRepository(MessageRecordDbContext context)
        {
            _context = context;
        }

        public async Task SaveMessageAsync(MessageRecord messageRecord)
        {
           _context.Messages.Add(messageRecord);
            await _context.SaveChangesAsync();
        }
    }
}
