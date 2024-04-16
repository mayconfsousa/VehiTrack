﻿using Microsoft.EntityFrameworkCore;
using VehiTrack.Models;

namespace VehiTrack
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<RefuelingRecord> RefuelingRecords { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(AppSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /************************************************************************
             * TABLE: users
             ************************************************************************/

            builder.Entity<User>().ToTable("users");

            // COLUMN: id
            builder.Entity<User>().Property(u => u.Id).HasColumnName("id").UseIdentityColumn();

            // COLUMN: first_name
            builder
                .Entity<User>()
                .Property(u => u.FirstName)
                .HasColumnName("first_name")
                .IsRequired();

            // COLUMN: last_name
            builder
                .Entity<User>()
                .Property(u => u.LastName)
                .HasColumnName("last_name")
                .IsRequired();

            // COLUMN: username
            builder
                .Entity<User>()
                .Property(u => u.Username)
                .HasColumnName("username")
                .IsRequired();
            builder.Entity<User>().HasIndex(u => u.Username).IsUnique();

            // COLUMN: telegram_id
            builder
                .Entity<User>()
                .Property(u => u.TelegramId)
                .HasColumnName("telegram_id")
                .IsRequired();
            builder.Entity<User>().HasIndex(u => u.TelegramId).IsUnique();

            // RELATIONSHIP: vehicles -> users
            builder
                .Entity<User>()
                .HasMany(u => u.Vehicles)
                .WithOne(v => v.User)
                .HasForeignKey(v => v.UserId);

            /**************************************************************
             * TABLE: vehicles
             **************************************************************/

            builder.Entity<Vehicle>().ToTable("vehicles");

            // COLUMN: id
            builder.Entity<Vehicle>().Property(v => v.Id).HasColumnName("id").UseIdentityColumn();

            // COLUMN: name
            builder.Entity<Vehicle>().Property(v => v.Name).HasColumnName("name").IsRequired();

            // COLUMN: user_id
            builder
                .Entity<Vehicle>()
                .Property(v => v.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            // RELATIONSHIP: refueling_records -> vehicles
            builder
                .Entity<Vehicle>()
                .HasMany(v => v.RefuelingRecords)
                .WithOne(r => r.Vehicle)
                .HasForeignKey(r => r.VehicleId);

            /***************************************************************
             * TABLE: refueling_records
             ***************************************************************/

            builder.Entity<RefuelingRecord>().ToTable("refueling_records");

            // COLUMN: id
            builder
                .Entity<RefuelingRecord>()
                .Property(r => r.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            // COLUMN: date
            builder
                .Entity<RefuelingRecord>()
                .Property(r => r.Date)
                .HasColumnName("date")
                .IsRequired();

            // COLUMN: odometer
            builder
                .Entity<RefuelingRecord>()
                .Property(r => r.Odometer)
                .HasColumnName("odometer")
                .IsRequired();

            // COLUMN: is_full
            builder
                .Entity<RefuelingRecord>()
                .Property(r => r.IsFull)
                .HasColumnName("is_full")
                .IsRequired();

            // CULUMN: amount
            builder
                .Entity<RefuelingRecord>()
                .Property(r => r.Amount)
                .HasColumnName("amount")
                .IsRequired();

            // COLUMN: price
            builder
                .Entity<RefuelingRecord>()
                .Property(r => r.Price)
                .HasColumnName("price")
                .IsRequired();

            // COLUMN: total_price
            builder
                .Entity<RefuelingRecord>()
                .Property(r => r.TotalPrice)
                .HasColumnName("total_price")
                .IsRequired();

            // COLUMN: fuel_type_id
            builder
                .Entity<RefuelingRecord>()
                .Property(r => r.FuelTypeId)
                .HasColumnName("fuel_type_id")
                .IsRequired();

            // COLUMN: vehicle_id
            builder
                .Entity<RefuelingRecord>()
                .Property(r => r.VehicleId)
                .HasColumnName("vehicle_id")
                .IsRequired();

            /**************************************************************************************
             * TABLE: fuel_types
             **************************************************************************************/

            builder.Entity<FuelType>().ToTable("fuel_types");

            // COLUMN: id
            builder.Entity<FuelType>().Property(f => f.Id).HasColumnName("id").UseIdentityColumn();

            // COLUMN: name
            builder.Entity<FuelType>().Property(f => f.Name).HasColumnName("name").IsRequired();

            // RELATIONSHIP: refueling_records -> fuel_types
            builder
                .Entity<FuelType>()
                .HasMany(f => f.RefuelingRecords)
                .WithOne(r => r.FuelType)
                .HasForeignKey(r => r.FuelTypeId);

            base.OnModelCreating(builder);
        }
    }
}
