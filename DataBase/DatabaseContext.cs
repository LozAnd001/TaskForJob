using Microsoft.EntityFrameworkCore;
using DataBase.Models;

namespace DataBase
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) 
        {
           
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Establishment>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Places)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<EstablishmentTag>()
                .HasKey(pt => new { pt.EstablishmentId, pt.TagId });

            modelBuilder.Entity<EstablishmentTag>()
                .HasOne(pt => pt.Establishment)
                .WithMany(p => p.EstablishmentTags)
                .HasForeignKey(pt => pt.EstablishmentId);

            modelBuilder.Entity<EstablishmentTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.EstablishmentTags)
                .HasForeignKey(pt => pt.TagId);
        }


    }
}
