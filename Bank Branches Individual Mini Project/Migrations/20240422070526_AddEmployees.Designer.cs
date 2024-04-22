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
    [Migration("20240422070526_AddEmployees")]
    partial class AddEmployees
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

            modelBuilder.Entity("Bank_Branches_Individual_Mini_Project.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BankBranchId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CivilId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BankBranchId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Bank_Branches_Individual_Mini_Project.Models.Employee", b =>
                {
                    b.HasOne("Bank_Branches_Individual_Mini_Project.Models.BankBranch", "BankBranch")
                        .WithMany("Employees")
                        .HasForeignKey("BankBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankBranch");
                });

            modelBuilder.Entity("Bank_Branches_Individual_Mini_Project.Models.BankBranch", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
