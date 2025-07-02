using Microsoft.EntityFrameworkCore;
using Zappor.Domain.Entities;

namespace Zappor.Infrastructure.Persistence
{
    public class ZapporDbContext : DbContext
    {
        public ZapporDbContext(DbContextOptions<ZapporDbContext> options)
            : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ZapporDbContext).Assembly);
        }

    }
}
