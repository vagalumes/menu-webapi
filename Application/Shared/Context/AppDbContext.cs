using Application.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Shared.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Adress> Adress { get; set; }
        public DbSet<Information> Information { get; set; }
        public DbSet<Login> Access { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<OpeningHours> ServiceHours { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<UsersImages> UsersImages { get; set; }
        public DbSet<RestaurantsImages> RestaurantsImages { get; set; }
        public DbSet<MenuItemsImages> MenuItemsImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Restaurant>()
                       .HasOne(r => r.Information)
                       .WithOne(re => re.Restaurant)
                       .OnDelete(DeleteBehavior.Cascade);

            _ = modelBuilder.Entity<Restaurant>()
                       .HasOne(r => r.Adress)
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

            _ = modelBuilder.Entity<Restaurant>()
                       .HasMany(r => r.ServiceHours)
                       .WithOne(re => re.Restaurant)
                       .OnDelete(DeleteBehavior.Cascade);

            _ = modelBuilder.Entity<Restaurant>()
                       .HasMany(r => r.Images)
                       .WithOne(re => re.Restaurant)
                       .OnDelete(DeleteBehavior.Cascade);

            _ = modelBuilder.Entity<Restaurant>()
                       .HasMany(r => r.MenuItems)
                       .WithOne(re => re.Restaurant)
                       .OnDelete(DeleteBehavior.Cascade);

            _ = modelBuilder.Entity<MenuItem>()
                       .HasMany(m => m.Images)
                       .WithOne(me => me.MenuItem)
                       .OnDelete(DeleteBehavior.Cascade);

            _ = modelBuilder.Entity<User>()
                       .HasOne(u => u.Adress)
                       .WithOne(us => us.User)
                       .OnDelete(DeleteBehavior.Cascade);

            _ = modelBuilder.Entity<User>()
                       .HasOne(u => u.Login)
                       .WithOne(us => us.User)
                       .OnDelete(DeleteBehavior.Cascade);

            _ = modelBuilder.Entity<User>()
                       .HasMany(u => u.Images)
                       .WithOne(us => us.User)
                       .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
