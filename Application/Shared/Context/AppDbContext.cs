using Application.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Shared.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public required DbSet<Address> Address { get; init; }
    public required DbSet<Information> Information { get; init; }
    public required DbSet<Restaurant> Restaurants { get; init; }
    public required DbSet<Schedule> Schedules { get; init; }
    public required DbSet<MenuItem> MenuItem { get; init; }
    public required DbSet<RestaurantsImages> RestaurantsImages { get; init; }
    public required DbSet<MenuItemsImages> MenuItemsImages { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<Restaurant>()
            .HasOne(r => r.Information)
            .WithOne(re => re.Restaurant)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        _ = modelBuilder.Entity<Restaurant>()
            .HasOne(r => r.Address)
            .WithOne(re => re.Restaurant)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        _ = modelBuilder.Entity<Address>()
            .HasOne(a => a.Restaurant)
            .WithOne(re => re.Address)
            .OnDelete(DeleteBehavior.Cascade);

        _ = modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Images)
            .WithOne(re => re.Restaurant)
            .OnDelete(DeleteBehavior.Cascade);

        _ = modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.MenuItems)
            .WithOne(re => re.Restaurant)
            .OnDelete(DeleteBehavior.Cascade);

        _ = modelBuilder.Entity<Information>()
            .HasMany(i => i.Schedules)
            .WithOne(s => s.Information)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        _ = modelBuilder.Entity<MenuItem>()
            .HasMany(m => m.Images)
            .WithOne(me => me.MenuItem)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}