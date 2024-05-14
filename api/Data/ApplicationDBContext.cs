using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data{

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OrderMenuItem> OrderMenuItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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