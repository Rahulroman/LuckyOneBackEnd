using LuckyOne.Entity;
using Microsoft.EntityFrameworkCore;

namespace LuckyOne.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<WalletPoints> WalletPoints { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<ContestUser> ContestUsers { get; set; }
        public DbSet<ContestPrize> ContestPrizes { get; set; }
        public DbSet<Notification> Notifications { get; set; }


    }
}
