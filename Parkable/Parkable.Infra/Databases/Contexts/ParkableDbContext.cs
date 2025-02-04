using Microsoft.EntityFrameworkCore;
using Parkable.Infra.Databases.Entities;

namespace Parkable.Infra.Databases.Contexts
{
    public class ParkableDbContext : DbContext
    {
        public ParkableDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(o => o.Id);

                entity.HasMany(o => o.Cars)
                    .WithOne(c => c.Owner)
                    .HasForeignKey(c => c.OwnerId)
                    .IsRequired(true);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.HasOne(c => c.Owner)
                .WithMany(o => o.Cars)
                .HasForeignKey(c => c.OwnerId)
                .IsRequired(true);
            });

            modelBuilder.Entity<User>(entity => entity.HasKey(c => c.Id));
        }
    }
}
