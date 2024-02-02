﻿// <auto-generated />
using System;
using ApiCatalogo.Repositories.db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiCatalogo.Migrations
{
    [DbContext(typeof(SystemDbContext))]
    [Migration("20240202210119_ProductSeed")]
    partial class ProductSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiCatalogo.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ImgUrl = "https://img.com.br",
                            Name = "Cars"
                        },
                        new
                        {
                            Id = 2L,
                            ImgUrl = "https://img.com.br",
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 3L,
                            ImgUrl = "https://img.com.br",
                            Name = "Smartphones"
                        },
                        new
                        {
                            Id = 4L,
                            ImgUrl = "https://img.com.br",
                            Name = "Books"
                        },
                        new
                        {
                            Id = 5L,
                            ImgUrl = "https://img.com.br",
                            Name = "Clothes"
                        });
                });

            modelBuilder.Entity("ApiCatalogo.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("RegisterData")
                        .HasColumnType("datetime2");

                    b.Property<double>("Stock")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CategoryId = 1L,
                            Description = "Fiat Punto",
                            ImgUrl = "https://img.com.br",
                            Name = "Punto",
                            Price = 25000.0,
                            RegisterData = new DateTime(2024, 2, 2, 18, 1, 19, 67, DateTimeKind.Local).AddTicks(2490),
                            Stock = 2.0
                        },
                        new
                        {
                            Id = 2L,
                            CategoryId = 1L,
                            Description = "Ford Fiesta",
                            ImgUrl = "https://img.com.br",
                            Name = "Fiesta",
                            Price = 15000.0,
                            RegisterData = new DateTime(2024, 2, 2, 18, 1, 19, 67, DateTimeKind.Local).AddTicks(2506),
                            Stock = 1.0
                        },
                        new
                        {
                            Id = 3L,
                            CategoryId = 2L,
                            Description = "Apple MacBook PRO",
                            ImgUrl = "https://img.com.br",
                            Name = "MacBook",
                            Price = 5000.0,
                            RegisterData = new DateTime(2024, 2, 2, 18, 1, 19, 67, DateTimeKind.Local).AddTicks(2508),
                            Stock = 10.0
                        },
                        new
                        {
                            Id = 4L,
                            CategoryId = 3L,
                            Description = "Apple Iphone 12",
                            ImgUrl = "https://img.com.br",
                            Name = "Iphone 12",
                            Price = 3000.0,
                            RegisterData = new DateTime(2024, 2, 2, 18, 1, 19, 67, DateTimeKind.Local).AddTicks(2509),
                            Stock = 5.0
                        },
                        new
                        {
                            Id = 5L,
                            CategoryId = 3L,
                            Description = "Galaxy S23 Ultra",
                            ImgUrl = "https://img.com.br",
                            Name = "Galaxy s23 ultra",
                            Price = 3000.0,
                            RegisterData = new DateTime(2024, 2, 2, 18, 1, 19, 67, DateTimeKind.Local).AddTicks(2511),
                            Stock = 3.0
                        });
                });

            modelBuilder.Entity("ApiCatalogo.Entities.Product", b =>
                {
                    b.HasOne("ApiCatalogo.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ApiCatalogo.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}