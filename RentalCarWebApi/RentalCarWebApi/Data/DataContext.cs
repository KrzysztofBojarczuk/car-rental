using Microsoft.EntityFrameworkCore;
using RentalCarWebApi.Models;

namespace RentalCarWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasOne<Rental>(s => s.Rental)
                .WithMany(r => r.Members)
                .HasForeignKey(s => s.RentalId);


            modelBuilder.Entity<CarRental>()
                .HasKey(g => new { g.RentalId, g.CarId });

            modelBuilder.Entity<Rental>()
                .Property(p => p.TotalCost)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Car>()
                .Property(p => p.RentalCost)
                .HasColumnType("decimal(18,2)");
        }




        public DbSet<Car> Car { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<CarRental> CarRentals { get; set; }
    }
}

