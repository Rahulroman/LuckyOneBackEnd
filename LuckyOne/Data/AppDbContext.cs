using LuckyOne.Entity;
using Microsoft.EntityFrameworkCore;

namespace LuckyOne.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();


    }
}
