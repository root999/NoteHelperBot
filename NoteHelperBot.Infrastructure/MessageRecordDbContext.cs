using Microsoft.EntityFrameworkCore;
using NoteHelperBot.Infrastructure.Models;

namespace NoteHelperBot.Infrastructure
{
    public class MessageRecordDbContext : DbContext
    {
        public MessageRecordDbContext(DbContextOptions<MessageRecordDbContext> options) : base(options) { }

        public DbSet<MessageRecord> Messages => Set<MessageRecord>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MessageRecord>().ToTable("MessageRecords");

            modelBuilder.Entity<MessageRecord>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.UserId).IsRequired();
                b.Property(x => x.Message).IsRequired();
                b.Property(x => x.CreatedAt).IsRequired();
                b.HasIndex(x => x.UserId);
            });

        }
    }
}
