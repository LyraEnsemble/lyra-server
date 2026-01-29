using Microsoft.EntityFrameworkCore;
using Planning.Domain.Entities;

namespace Planning.Infrastructure.Data
{
    public class PlanningDbContext : DbContext
    {
        public PlanningDbContext(DbContextOptions<PlanningDbContext> options) : base(options) { }
        public DbSet<Setlist> Setlists { get; set; }
        public DbSet<SetlistItem> SetlistItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("planning");
            modelBuilder.Entity<Setlist>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

                // INDISPENSABLE: El código debe ser único para que al buscarlo sea rápido
                entity.HasIndex(e => e.AccessCode).IsUnique();
                entity.Property(e => e.AccessCode).IsRequired().HasMaxLength(10);
            });
            modelBuilder.Entity<SetlistItem>(entity =>
            {
                entity.HasKey(e => e.Id);

                // Relación: Si borras el Setlist, se borran sus items (Cascade)
                entity.HasOne<Setlist>()
                      .WithMany(s => s.Items)
                      .HasForeignKey(i => i.SetlistId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
