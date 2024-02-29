﻿// <auto-generated />
using System;
using InvoiceGenerateAppNew.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvoiceGenerateAppNew.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240227023205_Adding_InvoiceMaster_Tbl_To_DB")]
    partial class Adding_InvoiceMaster_Tbl_To_DB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.1.24081.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InvoiceGenerateAppNew.Models.InvoiceDetail", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceID"));

                    b.Property<decimal>("BalanceAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("Discounts")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("InvoiceMasterId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("TransDate")
                        .HasColumnType("date");

                    b.HasKey("InvoiceID");

                    b.HasIndex("InvoiceMasterId");

                    b.HasIndex("ProductId");

                    b.ToTable("InvoiceDetail");
                });

            modelBuilder.Entity("InvoiceGenerateAppNew.Models.InvoiceMaster", b =>
                {
                    b.Property<int>("InvoiceMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceMasterId"));

                    b.Property<int>("InvoiceID")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("InvoiceMasterId");

                    b.HasIndex("InvoiceID");

                    b.ToTable("InvoiceMasters");
                });

            modelBuilder.Entity("InvoiceGenerateAppNew.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StoreQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductName = "Keyboard",
                            ProductPrice = 2500m,
                            StoreQuantity = 50
                        },
                        new
                        {
                            ProductId = 2,
                            ProductName = "Mouse",
                            ProductPrice = 1000m,
                            StoreQuantity = 100
                        },
                        new
                        {
                            ProductId = 3,
                            ProductName = "Monitor",
                            ProductPrice = 40000m,
                            StoreQuantity = 28
                        },
                        new
                        {
                            ProductId = 4,
                            ProductName = "UPS",
                            ProductPrice = 12500m,
                            StoreQuantity = 35
                        },
                        new
                        {
                            ProductId = 5,
                            ProductName = "SSD",
                            ProductPrice = 8000m,
                            StoreQuantity = 20
                        },
                        new
                        {
                            ProductId = 6,
                            ProductName = "Pen-Drive",
                            ProductPrice = 4000m,
                            StoreQuantity = 30
                        });
                });

            modelBuilder.Entity("InvoiceGenerateAppNew.Models.InvoiceDetail", b =>
                {
                    b.HasOne("InvoiceGenerateAppNew.Models.InvoiceMaster", null)
                        .WithMany("Items")
                        .HasForeignKey("InvoiceMasterId");

                    b.HasOne("InvoiceGenerateAppNew.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("InvoiceGenerateAppNew.Models.InvoiceMaster", b =>
                {
                    b.HasOne("InvoiceGenerateAppNew.Models.InvoiceDetail", "InvoiceDetail")
                        .WithMany()
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvoiceDetail");
                });

            modelBuilder.Entity("InvoiceGenerateAppNew.Models.InvoiceMaster", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
