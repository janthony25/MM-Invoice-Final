﻿// <auto-generated />
using System;
using MM_Invoice_Final.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MM_Invoice_Final.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240722054809_Add tblInvoice and tblInvoiceItem")]
    partial class AddtblInvoiceandtblInvoiceItem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MM_Invoice_Final.Models.Entities.tblCar", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"));

                    b.Property<string>("CarMake")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarRego")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("tblCar");
                });

            modelBuilder.Entity("MM_Invoice_Final.Models.Entities.tblCustomer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("tblCustomer");
                });

            modelBuilder.Entity("MM_Invoice_Final.Models.Entities.tblInvoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"));

                    b.Property<decimal?>("AmountPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("IssueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("LaborPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentTerm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TaxAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceId");

                    b.HasIndex("CarId");

                    b.ToTable("tblInvoice");
                });

            modelBuilder.Entity("MM_Invoice_Final.Models.Entities.tblInvoiceItem", b =>
                {
                    b.Property<int>("InvoiceItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceItemId"));

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("InvoiceItemId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("tblInvoiceItem");
                });

            modelBuilder.Entity("MM_Invoice_Final.Models.Entities.tblCar", b =>
                {
                    b.HasOne("MM_Invoice_Final.Models.Entities.tblCustomer", "tblCustomer")
                        .WithMany("tblCar")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tblCustomer");
                });

            modelBuilder.Entity("MM_Invoice_Final.Models.Entities.tblInvoice", b =>
                {
                    b.HasOne("MM_Invoice_Final.Models.Entities.tblCar", "tblCar")
                        .WithMany("tblInvoice")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tblCar");
                });

            modelBuilder.Entity("MM_Invoice_Final.Models.Entities.tblInvoiceItem", b =>
                {
                    b.HasOne("MM_Invoice_Final.Models.Entities.tblInvoice", "tblInvoice")
                        .WithMany("tblInvoiceItem")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tblInvoice");
                });

            modelBuilder.Entity("MM_Invoice_Final.Models.Entities.tblCar", b =>
                {
                    b.Navigation("tblInvoice");
                });

            modelBuilder.Entity("MM_Invoice_Final.Models.Entities.tblCustomer", b =>
                {
                    b.Navigation("tblCar");
                });

            modelBuilder.Entity("MM_Invoice_Final.Models.Entities.tblInvoice", b =>
                {
                    b.Navigation("tblInvoiceItem");
                });
#pragma warning restore 612, 618
        }
    }
}
