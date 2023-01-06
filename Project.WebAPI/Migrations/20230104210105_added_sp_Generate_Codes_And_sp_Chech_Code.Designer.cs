﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.WebAPI.Context;

#nullable disable

namespace Project.WebAPI.Migrations
{
    [DbContext(typeof(CodeDbContext))]
    [Migration("20230104210105_added_sp_Generate_Codes_And_sp_Chech_Code")]
    partial class added_sp_Generate_Codes_And_sp_Chech_Code
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Project.WebAPI.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasMaxLength(15)
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 1, 5, 0, 1, 5, 342, DateTimeKind.Local).AddTicks(6917),
                            Password = "$2a$11$IIQzxzpfGej7x/Vm5ZzGkO7pJavVzuCX30l9cRJo.g/7EN33WOntK",
                            Role = 1,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 1, 5, 0, 1, 5, 342, DateTimeKind.Local).AddTicks(6935),
                            Password = "$2a$11$Nq.NQIaNXJdO/8JoBqlq6ewVQIRrY/Tw/UpzNJbRYYgpUAL1EN7bO",
                            Role = 2,
                            UserName = "user"
                        });
                });

            modelBuilder.Entity("Project.WebAPI.Models.Code", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Codes");
                });
#pragma warning restore 612, 618
        }
    }
}