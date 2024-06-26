﻿// <auto-generated />
using Bank_Branches_Individual_Mini_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank_Branches_Individual_Mini_Project.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20240421061604_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Bank_Branches_Individual_Mini_Project.Models.BankBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BranchManager")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BankBranches");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BranchManager = "Majed",
                            EmployeeCount = 4,
                            Location = "https://maps.app.goo.gl/s2aCpoGSUFZHa4KS8",
                            Name = "Khaldiya"
                        },
                        new
                        {
                            Id = 2,
                            BranchManager = "Ahmad",
                            EmployeeCount = 3,
                            Location = "https://maps.app.goo.gl/N1AwujroTFMhVbVj9",
                            Name = "Mansouriya"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
