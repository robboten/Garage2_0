﻿// <auto-generated />
using System;
using Garage2_0.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Garage20.Migrations
{
    [DbContext(typeof(GarageContext))]
    partial class GarageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Garage2_0.Models.BrandDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BrandDb", (string)null);
                });

            modelBuilder.Entity("Garage2_0.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owner", (string)null);
                });

            modelBuilder.Entity("Garage2_0.Models.TypeDb", b =>
                {
                    b.Property<int>("TypeDbId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeDbId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeDbId");

                    b.ToTable("TypeDb", (string)null);
                });

            modelBuilder.Entity("Garage2_0.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Brand")
                        .HasColumnType("int");

                    b.Property<int?>("BrandDbId")
                        .HasColumnType("int");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNr")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<DateTime>("TimeOfArrival")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TypeDbId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.Property<int>("Wheels")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandDbId");

                    b.HasIndex("TypeDbId");

                    b.ToTable("Vehicle", (string)null);
                });

            modelBuilder.Entity("OwnerVehicle", b =>
                {
                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("OwnerId", "VehicleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("OwnerVehicle", (string)null);
                });

            modelBuilder.Entity("Garage2_0.Models.Vehicle", b =>
                {
                    b.HasOne("Garage2_0.Models.BrandDb", "BrandDb")
                        .WithMany("Vehicles")
                        .HasForeignKey("BrandDbId");

                    b.HasOne("Garage2_0.Models.TypeDb", "TypeDb")
                        .WithMany("Vehicles")
                        .HasForeignKey("TypeDbId");

                    b.Navigation("BrandDb");

                    b.Navigation("TypeDb");
                });

            modelBuilder.Entity("OwnerVehicle", b =>
                {
                    b.HasOne("Garage2_0.Models.Owner", null)
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Garage2_0.Models.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Garage2_0.Models.BrandDb", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Garage2_0.Models.TypeDb", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
