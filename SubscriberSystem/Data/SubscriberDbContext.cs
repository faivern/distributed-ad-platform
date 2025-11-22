using Microsoft.EntityFrameworkCore;
namespace SubscriberSystem.Data
{
    public class SubscriberDbContext : DbContext
    {
        public SubscriberDbContext(DbContextOptions<SubscriberDbContext> options)
            : base(options)
        {
        }
        public DbSet<Subscriber> Subscribers { get; set; }
    }
}