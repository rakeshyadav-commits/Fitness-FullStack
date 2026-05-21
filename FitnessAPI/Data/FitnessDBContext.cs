using FitnessAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessAPI.Data
{
    public class FitnessDBContext : DbContext
    {
        public FitnessDBContext(
            DbContextOptions<FitnessDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<BMIRecord> BMIRecords { get; set; }

        public DbSet<CalorieTracker> CalorieTracker { get; set; }
    }
}
namespace FitnessAPI.API.Data
{
    public class FitnessDBContext : DbContext
    {
        public FitnessDBContext(DbContextOptions<FitnessDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<UserRole>()
                .HasOne(u => u.User)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(r => r.Role)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<BMIRecord>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<BMIRecord>()
    .Property(x => x.Height)
    .HasPrecision(10, 2);

            modelBuilder.Entity<BMIRecord>()
                .Property(x => x.Weight)
                .HasPrecision(10, 2);

            modelBuilder.Entity<BMIRecord>()
                .Property(x => x.BMIValue)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CalorieTracker>()
                .Property(x => x.Quantity)
                .HasPrecision(10, 2);
        }
    }
}