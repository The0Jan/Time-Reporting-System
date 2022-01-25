﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NTR.Data;

#nullable disable

namespace NTR.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
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
                        .HasColumnType("longtext");

                    b.Property<bool>("Frozen")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ProjectCode")
                        .IsRequired()
                        .HasColumnType("varchar(95)");

                    b.Property<string>("SubcodeName")
                        .HasColumnType("varchar(95)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ActivityId");

                    b.HasIndex("ProjectCode");

                    b.HasIndex("SubcodeName");

                    b.HasIndex("UserId");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            ActivityId = 1,
                            Date = new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Fun Times",
                            Frozen = false,
                            ProjectCode = "ARG",
                            SubcodeName = "refactor",
                            Time = 100,
                            UserId = 1
                        },
                        new
                        {
                            ActivityId = 2,
                            Date = new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Funnier Times",
                            Frozen = false,
                            ProjectCode = "ARG",
                            SubcodeName = "debugging",
                            Time = 100,
                            UserId = 1
                        },
                        new
                        {
                            ActivityId = 3,
                            Date = new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Funniest Times",
                            Frozen = false,
                            ProjectCode = "ARG",
                            SubcodeName = "debugging",
                            Time = 100,
                            UserId = 1
                        },
                        new
                        {
                            ActivityId = 4,
                            Date = new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Funnnos Timos",
                            Frozen = false,
                            ProjectCode = "ARG",
                            SubcodeName = "lunch-break",
                            Time = 100,
                            UserId = 1
                        },
                        new
                        {
                            ActivityId = 5,
                            Date = new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Funmosity Timosity",
                            Frozen = false,
                            ProjectCode = "BARK",
                            SubcodeName = "deploying",
                            Time = 100,
                            UserId = 1
                        },
                        new
                        {
                            ActivityId = 6,
                            Date = new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Programming in C",
                            Frozen = false,
                            ProjectCode = "SMARK",
                            SubcodeName = "programming",
                            Time = 100,
                            UserId = 1
                        },
                        new
                        {
                            ActivityId = 7,
                            Date = new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Programming in C#",
                            Frozen = false,
                            ProjectCode = "SMARK",
                            SubcodeName = "programming",
                            Time = 100,
                            UserId = 1
                        },
                        new
                        {
                            ActivityId = 8,
                            Date = new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Waiting",
                            Frozen = false,
                            ProjectCode = "BARK",
                            SubcodeName = "compiling",
                            Time = 100,
                            UserId = 1
                        },
                        new
                        {
                            ActivityId = 9,
                            Date = new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Done waiting",
                            Frozen = false,
                            ProjectCode = "BARK",
                            SubcodeName = "compiling",
                            Time = 100,
                            UserId = 1
                        },
                        new
                        {
                            ActivityId = 10,
                            Date = new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Boss came",
                            Frozen = false,
                            ProjectCode = "BARK",
                            SubcodeName = "consulting",
                            Time = 100,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("NTR.Models.Project", b =>
                {
                    b.Property<string>("ProjectCode")
                        .HasColumnType("varchar(95)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectCode");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectCode = "ARG",
                            Active = true,
                            Budget = 1000,
                            Title = "ARGUS-15",
                            UserId = 1
                        },
                        new
                        {
                            ProjectCode = "BARK",
                            Active = true,
                            Budget = 1000,
                            Title = "BARKUS-16",
                            UserId = 1
                        },
                        new
                        {
                            ProjectCode = "SMARK",
                            Active = true,
                            Budget = 1000,
                            Title = "SMARKUS-17",
                            UserId = 2
                        },
                        new
                        {
                            ProjectCode = "DARK",
                            Active = false,
                            Budget = 1000,
                            Title = "DARKUS-18",
                            UserId = 3
                        });
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
                        .HasColumnType("varchar(95)");

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

                    b.HasData(
                        new
                        {
                            ProjectPartakeId = 1,
                            AcceptedTime = 0,
                            Month = 1,
                            ProjectCode = "ARG",
                            Submitted = false,
                            SubmittedTime = 400,
                            UserId = 1,
                            Year = 2022
                        },
                        new
                        {
                            ProjectPartakeId = 2,
                            AcceptedTime = 120,
                            Month = 1,
                            ProjectCode = "BARK",
                            Submitted = false,
                            SubmittedTime = 400,
                            UserId = 1,
                            Year = 2022
                        },
                        new
                        {
                            ProjectPartakeId = 3,
                            AcceptedTime = 200,
                            Month = 1,
                            ProjectCode = "SMARK",
                            Submitted = false,
                            SubmittedTime = 200,
                            UserId = 1,
                            Year = 2022
                        });
                });

            modelBuilder.Entity("NTR.Models.Subcode", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(95)");

                    b.Property<string>("ProjectCode")
                        .IsRequired()
                        .HasColumnType("varchar(95)");

                    b.HasKey("Name");

                    b.HasIndex("ProjectCode");

                    b.ToTable("Subcodes");

                    b.HasData(
                        new
                        {
                            Name = "refactor",
                            ProjectCode = "ARG"
                        },
                        new
                        {
                            Name = "debugging",
                            ProjectCode = "ARG"
                        },
                        new
                        {
                            Name = "lunch-break",
                            ProjectCode = "ARG"
                        },
                        new
                        {
                            Name = "testing",
                            ProjectCode = "ARG"
                        },
                        new
                        {
                            Name = "compiling",
                            ProjectCode = "BARK"
                        },
                        new
                        {
                            Name = "deploying",
                            ProjectCode = "BARK"
                        },
                        new
                        {
                            Name = "consulting",
                            ProjectCode = "BARK"
                        },
                        new
                        {
                            Name = "programming",
                            ProjectCode = "SMARK"
                        },
                        new
                        {
                            Name = "downtime",
                            ProjectCode = "DARK"
                        });
                });

            modelBuilder.Entity("NTR.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            First_Name = "kowalski"
                        },
                        new
                        {
                            UserId = 2,
                            First_Name = "szeregowy"
                        },
                        new
                        {
                            UserId = 3,
                            First_Name = "rico"
                        });
                });

            modelBuilder.Entity("NTR.Models.Activity", b =>
                {
                    b.HasOne("NTR.Models.Project", "Project")
                        .WithMany("Activities")
                        .HasForeignKey("ProjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NTR.Models.Subcode", "Subcode")
                        .WithMany()
                        .HasForeignKey("SubcodeName");

                    b.HasOne("NTR.Models.User", "User")
                        .WithMany("Activities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Subcode");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NTR.Models.Project", b =>
                {
                    b.HasOne("NTR.Models.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NTR.Models.Subcode", b =>
                {
                    b.HasOne("NTR.Models.Project", "Projects")
                        .WithMany("Subcodes")
                        .HasForeignKey("ProjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("NTR.Models.Project", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("Subcodes");
                });

            modelBuilder.Entity("NTR.Models.User", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("ProjectPartakes");

                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
