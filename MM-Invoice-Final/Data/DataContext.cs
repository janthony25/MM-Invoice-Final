using Microsoft.EntityFrameworkCore;
using MM_Invoice_Final.Models.Entities;

namespace MM_Invoice_Final.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<tblCustomer> tblCustomer { get; set; }
        public DbSet<tblCar> tblCar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one-to-many connection tblCustomer-tblCar
            modelBuilder.Entity<tblCustomer>()
                .HasMany(c => c.tblCar)
                .WithOne(ca => ca.tblCustomer)
                .HasForeignKey(ca => ca.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
