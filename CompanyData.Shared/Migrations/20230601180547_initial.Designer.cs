﻿// <auto-generated />
using System;
using CompanyData.Shared.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompanyData.Shared.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230601180547_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CompanyData.Shared.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            Id = new Guid("43738933-acf0-4479-8624-0ef1bec0383d"),
                            Address = "8,Mesa Road",
                            City = "Houston",
                            State = "Texas"
                        },
                        new
                        {
                            Id = new Guid("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"),
                            Address = "12,ogunnaike street GRA",
                            City = "Ikeja",
                            State = "Lagos"
                        });
                });

            modelBuilder.Entity("CompanyData.Shared.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("Supervisor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("WagesInDollar")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e237f904-35e4-4f31-b854-b49c61a8b443"),
                            CompanyId = new Guid("43738933-acf0-4479-8624-0ef1bec0383d"),
                            Department = "Digital",
                            Email = "digitalteam@gmail.com",
                            FirstName = "Isaac",
                            JobRole = "Lead",
                            LastName = "Paul",
                            PhoneNumber = "+1312754448",
                            WagesInDollar = 4500.0
                        },
                        new
                        {
                            Id = new Guid("1eff9885-7088-4da3-9b8c-d086cfa99ee6"),
                            CompanyId = new Guid("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"),
                            Department = "Digital",
                            Email = "paulI@gmail.com",
                            FirstName = "Cherri",
                            JobRole = "Media",
                            LastName = "Evans",
                            MiddleName = "Beauty",
                            PhoneNumber = "07027544487",
                            Supervisor = new Guid("43738933-acf0-4479-8624-0ef1bec0383d"),
                            WagesInDollar = 2500.0
                        });
                });

            modelBuilder.Entity("CompanyData.Shared.Models.Employee", b =>
                {
                    b.HasOne("CompanyData.Shared.Models.Company", null)
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyData.Shared.Models.Company", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}