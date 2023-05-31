﻿// <auto-generated />
using System;
using AwesomeHotel_HotelAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AwesomeHotel_HotelAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AwesomeHotel_HotelAPI.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenities = "Air condition, natural light",
                            Area = 30,
                            CreatedDate = new DateTime(2023, 5, 31, 11, 21, 23, 814, DateTimeKind.Local).AddTicks(48),
                            Details = "Best room for couples",
                            ImageUrl = "www.awesomehotels.com/OceanView.jpg",
                            Name = "NewOceanView",
                            Occupancy = 3,
                            Rate = 120,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Amenities = "Air condition, smoking area",
                            Area = 25,
                            CreatedDate = new DateTime(2023, 5, 31, 11, 21, 23, 814, DateTimeKind.Local).AddTicks(106),
                            Details = "Best room for business",
                            ImageUrl = "www.awesomehotels.com/StreetView.jpg",
                            Name = "StreetView",
                            Occupancy = 2,
                            Rate = 100,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Amenities = "Air condition, free coffee",
                            Area = 50,
                            CreatedDate = new DateTime(2023, 5, 31, 11, 21, 23, 814, DateTimeKind.Local).AddTicks(111),
                            Details = "Best room for large familes",
                            ImageUrl = "www.awesomehotels.com/Penthouse.jpg",
                            Name = "Penthouse",
                            Occupancy = 5,
                            Rate = 150,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Amenities = "Air condition, free drink, extra security",
                            Area = 50,
                            CreatedDate = new DateTime(2023, 5, 31, 11, 21, 23, 814, DateTimeKind.Local).AddTicks(115),
                            Details = "Most exclusive room",
                            ImageUrl = "www.awesomehotels.com/Presidential.jpg",
                            Name = "Presidential",
                            Occupancy = 3,
                            Rate = 200,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
