using Microsoft.EntityFrameworkCore;
using Tixer.Models;

namespace Tixer.Context
{
    public class TixerDbContext(DbContextOptions<TixerDbContext> options) : DbContext(options)
    {
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Ticket>()
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }

        public override int SaveChanges()
        {
            SetUpdatedAtColumn();

            return base.SaveChanges();
        }

        private void SetUpdatedAtColumn()
        {
            var entitiesModified = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Ticket && e.State == EntityState.Modified)
                .Select(x => x.Entity as Ticket);

            foreach (var entity in entitiesModified)
            {
                entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
