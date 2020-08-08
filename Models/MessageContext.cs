using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class MessageContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        protected MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}