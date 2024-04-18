﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VehiTrack;

#nullable disable

namespace VehiTrack.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20240418145335_AlteracoesGeraisNoBancoDeDados")]
    partial class AlteracoesGeraisNoBancoDeDados
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VehiTrack.Models.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("fuel_types", (string)null);
                });

            modelBuilder.Entity("VehiTrack.Models.RefuelingRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int>("FuelTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("fuel_type_id");

                    b.Property<bool>("IsFull")
                        .HasColumnType("boolean")
                        .HasColumnName("is_full");

                    b.Property<int>("OdometerCounter")
                        .HasColumnType("integer")
                        .HasColumnName("odometer_counter");

                    b.Property<double>("Quantity")
                        .HasColumnType("double precision")
                        .HasColumnName("quantity");

                    b.Property<double>("TotalCost")
                        .HasColumnType("double precision")
                        .HasColumnName("total_cost");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("double precision")
                        .HasColumnName("unity_price");

                    b.Property<int>("VehicleId")
                        .HasColumnType("integer")
                        .HasColumnName("vehicle_id");

                    b.HasKey("Id");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("VehicleId");

                    b.ToTable("refueling_records", (string)null);
                });

            modelBuilder.Entity("VehiTrack.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<long>("TelegramId")
                        .HasColumnType("bigint")
                        .HasColumnName("telegram_id");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("TelegramId")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("VehiTrack.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "Name")
                        .IsUnique();

                    b.ToTable("vehicles", (string)null);
                });

            modelBuilder.Entity("VehiTrack.Models.RefuelingRecord", b =>
                {
                    b.HasOne("VehiTrack.Models.FuelType", "FuelType")
                        .WithMany("RefuelingRecords")
                        .HasForeignKey("FuelTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VehiTrack.Models.Vehicle", "Vehicle")
                        .WithMany("RefuelingRecords")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuelType");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VehiTrack.Models.Vehicle", b =>
                {
                    b.HasOne("VehiTrack.Models.User", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("VehiTrack.Models.FuelType", b =>
                {
                    b.Navigation("RefuelingRecords");
                });

            modelBuilder.Entity("VehiTrack.Models.User", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("VehiTrack.Models.Vehicle", b =>
                {
                    b.Navigation("RefuelingRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
