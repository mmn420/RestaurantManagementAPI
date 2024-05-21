using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data{

public class ApplicationDBContext : IdentityDbContext<User>
{
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<OrderMenuItem> OrderMenuItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        List<IdentityRole> roles = new List<IdentityRole> {
            new IdentityRole { Name = "User", NormalizedName = "USER" },
            new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" }
        };
        modelBuilder.Entity<IdentityRole>().HasData(roles);
        modelBuilder.Entity<OrderMenuItem>()
            .HasKey(om => new { om.OrderId, om.MenuItemId }); // Composite primary key

        modelBuilder.Entity<OrderMenuItem>()
            .HasOne(om => om.Order)
            .WithMany(o => o.OrderMenuItems)
            .HasForeignKey(om => om.OrderId);

        modelBuilder.Entity<OrderMenuItem>()
            .HasOne(om => om.MenuItem)
            .WithMany(m => m.OrderMenuItems)
            .HasForeignKey(om => om.MenuItemId);
    }
}
}