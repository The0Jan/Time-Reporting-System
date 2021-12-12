﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NTR.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NTR.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211212093726_SecondaryMigrations")]
    partial class SecondaryMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("NTR.Models.ActivityModel", b =>
                {
                    b.Property<int>("ActivityModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("Frozen")
                        .HasColumnType("boolean");

                    b.Property<string>("ProjectModelId")
                        .HasColumnType("text");

                    b.Property<string>("SubcodeModelId")
                        .HasColumnType("text");

                    b.Property<int>("Time")
                        .HasColumnType("integer");

                    b.Property<int>("UserModelId")
                        .HasColumnType("integer");

                    b.HasKey("ActivityModelId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("NTR.Models.ProjectModel", b =>
                {
                    b.Property<int>("ProjectModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("UserModelId")
                        .HasColumnType("integer");

                    b.Property<bool>("active")
                        .HasColumnType("boolean");

                    b.HasKey("ProjectModelId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("NTR.Models.SubcodeModel", b =>
                {
                    b.Property<string>("SubcodeModelId")
                        .HasColumnType("text");

                    b.Property<string>("ProjectModelId")
                        .HasColumnType("text");

                    b.HasKey("SubcodeModelId");

                    b.ToTable("Subcodes");
                });

            modelBuilder.Entity("NTR.Models.UserModel", b =>
                {
                    b.Property<int>("UserModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("First_Name")
                        .HasColumnType("text");

                    b.Property<string>("Last_Name")
                        .HasColumnType("text");

                    b.HasKey("UserModelId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
