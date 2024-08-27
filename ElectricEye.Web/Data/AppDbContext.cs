using ElectricEye.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElectricEye.Web.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EnergyUsage> EnergyUsages { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<AlertSetting> AlertSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EnergyUsage>()
                .Property(e => e.Consumption)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ContactMessage>()
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
