using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models.ValueObject;

namespace SalesWebMvc.Models
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>()
                .OwnsOne<Name>(s => s.Name, cb =>
                {
                    cb.Property(c => c.FirstName)
                        .HasColumnName("FirstName")
                        .HasColumnType("varchar(30)")
                        .IsRequired();

                    cb.Property(c => c.LastName)
                        .HasColumnName("LastName")
                        .HasColumnType("varchar(50)")
                        .IsRequired();
                });

            modelBuilder.Entity<Seller>()
                .OwnsOne<Email>(s => s.Email, cb =>
                {
                    cb.Property(c => c.Address)
                        .HasColumnName("Email")
                        .HasColumnType("varchar(100)")
                        .IsRequired();

                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
