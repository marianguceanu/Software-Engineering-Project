using Microsoft.EntityFrameworkCore;
using SE.Models;

namespace SE.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Destination> Destinations { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<UserDestination> UserDestinations { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // User one to many UserDestination
            modelBuilder.Entity<UserDestination>()
                .HasOne(ud => ud.User)
                .WithMany(u => u.AbsUserDestinations)
                .HasForeignKey(ud => ud.UserId);

            // Destination one to many UserDestination
            modelBuilder.Entity<UserDestination>()
                .HasOne(ud => ud.Destination)
                .WithMany(d => d.AbsUserDestinations)
                .HasForeignKey(ud => ud.DestinationId);

            // UserDestination composite key
            modelBuilder.Entity<UserDestination>()
                .HasKey(ud => new { ud.UserId, ud.DestinationId });

            // Unique indexes
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
            modelBuilder.Entity<Destination>()
                .HasIndex(d => d.Title)
                .IsUnique();
        }
    }
}