using Application.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Shared.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Address> Address { get; set; } = null!;
        public DbSet<Information> Information { get; set; } = null!;
        public DbSet<Login> Access { get; set; } = null!;
        public DbSet<Payments> Payments { get; set; } = null!;
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Restaurant>()
                       .HasOne(r => r.Information)
                       .WithOne(re => re.Restaurant)
                       .OnDelete(DeleteBehavior.Cascade);

            _ = modelBuilder.Entity<Restaurant>()
                       .HasOne(r => r.Address)
                       .WithOne(re => re.Restaurant)
                       .OnDelete(DeleteBehavior.Cascade);

            _ = modelBuilder.Entity<Restaurant>()
                       .HasOne(r => r.Payments)
                       .WithOne(re => re.Restaurant)
                       .OnDelete(DeleteBehavior.Cascade);

            _ = modelBuilder.Entity<Restaurant>()
                       .HasOne(r => r.Login)
                       .WithOne(re => re.Restaurant)
                       .OnDelete(DeleteBehavior.Cascade);

            _ = modelBuilder.Entity<User>()
                       .HasOne(u => u.Address)
                       .WithOne(us => us.User)
                       .OnDelete(DeleteBehavior.Cascade);

            _ = modelBuilder.Entity<User>()
                       .HasOne(u => u.Login)
                       .WithOne(us => us.User)
                       .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
    }
}
