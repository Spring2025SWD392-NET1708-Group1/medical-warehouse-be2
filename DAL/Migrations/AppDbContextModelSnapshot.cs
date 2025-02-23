﻿// <auto-generated />
using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80c0ac22-9f4d-478e-8fe1-f01b4e6727b0"),
                            CategoryId = new Guid("aed8c311-739c-4264-83a1-8a5e8854c182"),
                            Description = "Pain reliever",
                            ExpiryDate = new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Paracetamol",
                            Price = 5.00m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = new Guid("1bfe3b07-5419-4718-bed9-0439016c7f78"),
                            CategoryId = new Guid("b7c51ee8-f942-4492-98b7-877b5777cd21"),
                            Description = "Disposable gloves",
                            ExpiryDate = new DateTime(2027, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Surgical Gloves",
                            Price = 10.00m,
                            Quantity = 200
                        });
                });

            modelBuilder.Entity("DAL.Entities.ItemCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aed8c311-739c-4264-83a1-8a5e8854c182"),
                            Name = "Medicine"
                        },
                        new
                        {
                            Id = new Guid("b7c51ee8-f942-4492-98b7-877b5777cd21"),
                            Name = "Surgical Equipment"
                        });
                });

            modelBuilder.Entity("DAL.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d9b4f38f-e9d4-4d2c-a479-746c16a6c697"),
                            OrderDate = new DateTime(2025, 2, 23, 11, 55, 21, 153, DateTimeKind.Utc).AddTicks(8907),
                            Status = 0,
                            TotalPrice = 0m,
                            UserId = new Guid("d8f0b849-d1a2-45d5-8a23-47772060c8fc")
                        });
                });

            modelBuilder.Entity("DAL.Entities.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5f1f6327-d2a7-46be-9b07-d5f6d5873501"),
                            ItemId = new Guid("80c0ac22-9f4d-478e-8fe1-f01b4e6727b0"),
                            OrderId = new Guid("d9b4f38f-e9d4-4d2c-a479-746c16a6c697"),
                            Price = 10.00m,
                            Quantity = 2
                        },
                        new
                        {
                            Id = new Guid("b8f9e273-3838-4657-9c9b-1e56b4a09d6e"),
                            ItemId = new Guid("1bfe3b07-5419-4718-bed9-0439016c7f78"),
                            OrderId = new Guid("d9b4f38f-e9d4-4d2c-a479-746c16a6c697"),
                            Price = 50.00m,
                            Quantity = 5
                        });
                });

            modelBuilder.Entity("DAL.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a3c27f19-e401-46d0-b404-99fa35744e9e"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("9c157f3e-d3ac-43b8-93b0-15e3d7f40ec1"),
                            Name = "Staff"
                        },
                        new
                        {
                            Id = new Guid("8bbdfc66-b6bb-4534-8c1c-c9a3b458ea3d"),
                            Name = "Customer"
                        },
                        new
                        {
                            Id = new Guid("09ac9b68-4b92-4f3b-b74e-2b1a5f6abf79"),
                            Name = "DeliveryUnit"
                        },
                        new
                        {
                            Id = new Guid("f8a8b1c9-24a1-484e-bb02-95b9601d4047"),
                            Name = "Supplier"
                        });
                });

            modelBuilder.Entity("DAL.Entities.Submission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Context")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("DAL.Entities.Transaction", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TransactionNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TransactionId");

                    b.HasIndex("OrderId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d8f0b849-d1a2-45d5-8a23-47772060c8fc"),
                            Email = "admin@example.com",
                            EmailConfirmed = false,
                            FullName = "xhuyz",
                            PasswordHash = "12345",
                            PhoneNumber = "",
                            RoleId = new Guid("a3c27f19-e401-46d0-b404-99fa35744e9e")
                        });
                });

            modelBuilder.Entity("DAL.Entities.Item", b =>
                {
                    b.HasOne("DAL.Entities.ItemCategory", "ItemCategory")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ItemCategory");
                });

            modelBuilder.Entity("DAL.Entities.Order", b =>
                {
                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.OrderDetail", b =>
                {
                    b.HasOne("DAL.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("DAL.Entities.Submission", b =>
                {
                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Transaction", b =>
                {
                    b.HasOne("DAL.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.HasOne("DAL.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DAL.Entities.ItemCategory", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("DAL.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("DAL.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
