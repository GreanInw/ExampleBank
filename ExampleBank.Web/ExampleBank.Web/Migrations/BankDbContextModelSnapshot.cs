﻿// <auto-generated />
using System;
using ExampleBank.Web.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExampleBank.Web.Migrations
{
    [DbContext(typeof(BankDbContext))]
    partial class BankDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExampleBank.Web.Data.Tables.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5c1ebb1c-ade1-43bd-85bc-977e81cadfc2"),
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 3, 11, 10, 14, 40, 515, DateTimeKind.Utc),
                            FirstName = "Jon",
                            LastName = "Snow",
                            ModifiedBy = "System",
                            ModifiedDate = new DateTime(2023, 3, 11, 10, 14, 40, 515, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("8382a5a4-c73f-4314-af3e-699c16fca88e"),
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 3, 11, 10, 14, 40, 515, DateTimeKind.Utc),
                            FirstName = "Aegon",
                            LastName = "Targaryen",
                            ModifiedBy = "System",
                            ModifiedDate = new DateTime(2023, 3, 11, 10, 14, 40, 515, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("ExampleBank.Web.Data.Tables.BankAccount", b =>
                {
                    b.Property<string>("IBAN")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(20,4)");

                    b.Property<string>("BankAccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IBAN", "AccountId");

                    b.HasIndex("AccountId");

                    b.ToTable("BankAccount");
                });

            modelBuilder.Entity("ExampleBank.Web.Data.Tables.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(20,4)");

                    b.Property<string>("IBAN")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("TransDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("ExampleBank.Web.Data.Tables.BankAccount", b =>
                {
                    b.HasOne("ExampleBank.Web.Data.Tables.Account", "Account")
                        .WithMany("BackAccounts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ExampleBank.Web.Data.Tables.Account", b =>
                {
                    b.Navigation("BackAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
