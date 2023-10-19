using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DBTheRideYouRentTest.Models
{
    public partial class RideYouRentDBContext : DbContext
    {
        public RideYouRentDBContext()
            : base("name=RideYouRentDBContext")
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Car_BodyType> Car_BodyType { get; set; }
        public virtual DbSet<Car_Make> Car_Make { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Inspector> Inspectors { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<ReturnCar> ReturnCars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(e => e.CarNo)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.Car_Make)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.BodyType)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.Avaliable)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.Rentals)
                .WithRequired(e => e.Car)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Car_BodyType>()
                .Property(e => e.BodyType_Description)
                .IsUnicode(false);

            modelBuilder.Entity<Car_Make>()
                .Property(e => e.Make_Description)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.Driver_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.DriverName)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.DriverAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.DriverEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.DriverContactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.Rentals)
                .WithRequired(e => e.Driver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inspector>()
                .Property(e => e.Inspector_no)
                .IsUnicode(false);

            modelBuilder.Entity<Inspector>()
                .Property(e => e.InspectorName)
                .IsUnicode(false);

            modelBuilder.Entity<Inspector>()
                .Property(e => e.InspectorEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Inspector>()
                .Property(e => e.InspectorMobile)
                .IsUnicode(false);

            modelBuilder.Entity<Inspector>()
                .HasMany(e => e.Rentals)
                .WithRequired(e => e.Inspector)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inspector>()
                .HasMany(e => e.ReturnCars)
                .WithRequired(e => e.Inspector)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rental>()
                .Property(e => e.Rental_no)
                .IsUnicode(false);

            modelBuilder.Entity<Rental>()
                .Property(e => e.RentalFee)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Rental>()
                .Property(e => e.CarNo)
                .IsUnicode(false);

            modelBuilder.Entity<Rental>()
                .Property(e => e.Inspector_no)
                .IsUnicode(false);

            modelBuilder.Entity<Rental>()
                .Property(e => e.Driver_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Rental>()
                .HasMany(e => e.ReturnCars)
                .WithRequired(e => e.Rental)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReturnCar>()
                .Property(e => e.Return_id)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnCar>()
                .Property(e => e.Rental_no)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnCar>()
                .Property(e => e.Inspector_no)
                .IsUnicode(false);
        }
    }
}
