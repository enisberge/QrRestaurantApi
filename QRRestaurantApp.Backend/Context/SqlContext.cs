using Microsoft.EntityFrameworkCore;
using QRRestaurantApp.Backend.Entities;

namespace QRRestaurantApp.Backend.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options):base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product>Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableSessionLog> TableSessionLogs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<OptionGroup> OptionGroups { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
                

            modelBuilder.Entity<Promotion>()
                .HasOne(p => p.Product)
                .WithMany(p=>p.Promotions)
                .HasForeignKey(p=>p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o=>o.Table)
                .WithMany(t => t.Orders)
                .HasForeignKey(o=>o.TableId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi=>oi.Order)
                .WithMany(o=>o.OrderItems)
                .HasForeignKey(oi=>oi.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 Table Code unique olmalı
            modelBuilder.Entity<Table>()
                .HasIndex(t => t.Code)
                .IsUnique();

            modelBuilder.Entity<TableSessionLog>()
                .HasOne(ts => ts.Table)
                .WithMany(t => t.TableSessionLogs)
                .HasForeignKey(ts => ts.TableId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OptionGroup>()
                .HasMany(og => og.OptionValues)
                .WithOne(ov => ov.OptionGroup)
                .HasForeignKey(ov => ov.OptionGroudId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
