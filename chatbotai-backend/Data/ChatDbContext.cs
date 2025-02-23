using chatbotai_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace chatbotai_backend.Data;

public class ChatDbContext : DbContext
{
    public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) { }

    public DbSet<ChatMessage> ChatMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatMessage>()
            .HasKey(m => m.Id);

        modelBuilder.Entity<ChatMessage>()
            .Property(m => m.ConversationId)
            .IsRequired();

        modelBuilder.Entity<ChatMessage>()
            .Property(m => m.Timestamp)
            .HasDefaultValueSql("GETUTCDATE()");
    }
}