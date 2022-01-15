﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NTR.Data;

namespace NTR.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NTR.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Frozen")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ProjectCode")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("SubcodeName")
                        .HasColumnType("text");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ActivityId");

                    b.HasIndex("ProjectCode");

                    b.HasIndex("UserId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("NTR.Models.Project", b =>
                {
                    b.Property<string>("ProjectCode")
                        .HasColumnType("varchar(767)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectCode");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("NTR.Models.ProjectPartake", b =>
                {
                    b.Property<int>("ProjectPartakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AcceptedTime")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<string>("ProjectCode")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<bool>("Submitted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("SubmittedTime")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ProjectPartakeId");

                    b.HasIndex("ProjectCode");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectPartakes");
                });

            modelBuilder.Entity("NTR.Models.Subcode", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ProjectCode")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("Name");

                    b.HasIndex("ProjectCode");

                    b.ToTable("Subcodes");
                });

            modelBuilder.Entity("NTR.Models.User", b =>
                {
                    b.Property<int>("UserModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserModelId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NTR.Models.Activity", b =>
                {
                    b.HasOne("NTR.Models.Subcode", "Subcode")
                        .WithMany()
                        .HasForeignKey("ProjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NTR.Models.Project", "Project")
                        .WithMany("Activities")
                        .HasForeignKey("ProjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NTR.Models.User", "User")
                        .WithMany("Activities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NTR.Models.Project", b =>
                {
                    b.HasOne("NTR.Models.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NTR.Models.ProjectPartake", b =>
                {
                    b.HasOne("NTR.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NTR.Models.User", "User")
                        .WithMany("ProjectPartakes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NTR.Models.Subcode", b =>
                {
                    b.HasOne("NTR.Models.Project", "Projects")
                        .WithMany("Subcodes")
                        .HasForeignKey("ProjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
