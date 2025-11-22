using Microsoft.EntityFrameworkCore;
namespace AdSystem.Data
{
    public class AdsDbContext : DbContext
    {
        public AdsDbContext(DbContextOptions<AdsDbContext> options)
            : base(options)
        {
        }
        public DbSet<Ads> Ads { get; set; }
        public DbSet<Advertisers> Advertisers { get; set; }
    }
}