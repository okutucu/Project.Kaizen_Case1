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
    [Migration("20230104204808_Initial_Create")]
    partial class Initial_Create
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
                            CreatedDate = new DateTime(2023, 1, 4, 23, 48, 7, 917, DateTimeKind.Local).AddTicks(832),
                            Password = "$2a$11$81BCfxJZD/VUjQMOgNBIzOtFcmCUM7B30W5Fg/xZ4x/KV3Ka2oeSC",
                            Role = 1,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 1, 4, 23, 48, 7, 917, DateTimeKind.Local).AddTicks(849),
                            Password = "$2a$11$qn/FZPzDfnU1hJ9/T49mOu46kRoDqoJYonAhTvjBHzRxPCUcrfPli",
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
