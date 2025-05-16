using Microsoft.EntityFrameworkCore;
using YourApp.DTO;

namespace YourApp.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }


    }
}
