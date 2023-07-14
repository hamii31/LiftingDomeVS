﻿// <auto-generated />
using System;
using LiftingDome.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LiftingDome.Data.Migrations
{
    [DbContext(typeof(LiftingDomeDbContext))]
    partial class LiftingDomeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LiftingDome.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("LiftingDome.Models.Calculator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("CalculatorMeassurments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Metric"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Imperial"
                        });
                });

            modelBuilder.Entity("LiftingDome.Models.Coach", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("LiftingDome.Models.Workout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CoachId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 7, 14, 9, 46, 4, 581, DateTimeKind.Utc).AddTicks(615));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("TraineeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("WorkoutCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("TraineeId");

                    b.HasIndex("WorkoutCategoryId");

                    b.ToTable("Workouts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1a552c28-d08e-461c-bd7b-77419a838c2a"),
                            CoachId = new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Probably the best way to build strength and size simultaneously. Either use 70-85% of your 1RM for all 5 sets or gradually warm up to a heavy top set of five.",
                            ImageURL = "https://global.discourse-cdn.com/tnation/original/4X/3/0/8/30832fc6dfb5cb54e95c9323e45720c3f7476d87.jpeg",
                            Price = 0m,
                            Title = "The 5X5 Method for size and strength",
                            TraineeId = new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"),
                            WorkoutCategoryId = 2
                        },
                        new
                        {
                            Id = new Guid("7763cbff-3c3b-4fe2-9857-137b4a9c70c2"),
                            CoachId = new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The best way for beginner and intermediate strength athletes to build strength.",
                            ImageURL = "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2013/08/Best-Set-and-Rep-Scheme-for-Your-Goal.jpg",
                            Price = 0m,
                            Title = "3X3 at 90% for pure strength",
                            TraineeId = new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"),
                            WorkoutCategoryId = 1
                        },
                        new
                        {
                            Id = new Guid("038b877c-3254-4609-b790-12c465c91c0f"),
                            CoachId = new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Boring, bland, but effective! The straight-forward 4x8 is another training protocol that bodybuilders have relied on for over 40 years. If it’s stuck around for that long, there’s good reason. It’s not flashy, but the basics never let you down. Doing 4 sets of 8, with each set getting you close to failure, is a decent way to stimulate growth, especially for beginners.",
                            ImageURL = "https://global.discourse-cdn.com/tnation/original/4X/4/e/c/4ec55b74a7a3a0795248ead7c9b155df540ee97f.jpeg",
                            Price = 0m,
                            Title = "The 4x8 rep scheme for unmatched muscle mass!",
                            TraineeId = new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"),
                            WorkoutCategoryId = 2
                        },
                        new
                        {
                            Id = new Guid("ae8de2b1-ff03-4453-9f51-8b1d46ee18a1"),
                            CoachId = new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Easiest way for strong people to do Metcon workouts without losing all of their strength gains is doing Zercher Cycles with heavy weight for a period of time. Deadlift the barbell off the ground, squat down and place it on your legs. Grab it in a zercher position and stand up. Squat down, place the barbell on your legs again, grab it with your hands and stand up. Lower the barbell down to the ground. That's one rep. Do 15-20 with some good weight on the barbell.",
                            ImageURL = "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2017/09/CrossFit-for-Meatheads.jpg",
                            Price = 20m,
                            Title = "CrossFit for Meatheads",
                            TraineeId = new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"),
                            WorkoutCategoryId = 3
                        });
                });

            modelBuilder.Entity("LiftingDome.Models.WorkoutCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("WorkoutCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Powerlifting"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bodybuilding"
                        },
                        new
                        {
                            Id = 3,
                            Name = "CrossFit"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LiftingDome.Models.Coach", b =>
                {
                    b.HasOne("LiftingDome.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LiftingDome.Models.Workout", b =>
                {
                    b.HasOne("LiftingDome.Models.Coach", "Coach")
                        .WithMany("CreatedWorkouts")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LiftingDome.Models.ApplicationUser", "Trainee")
                        .WithMany("AddedWorkouts")
                        .HasForeignKey("TraineeId");

                    b.HasOne("LiftingDome.Models.WorkoutCategory", "Category")
                        .WithMany("Workouts")
                        .HasForeignKey("WorkoutCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Coach");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("LiftingDome.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("LiftingDome.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiftingDome.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("LiftingDome.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LiftingDome.Models.ApplicationUser", b =>
                {
                    b.Navigation("AddedWorkouts");
                });

            modelBuilder.Entity("LiftingDome.Models.Coach", b =>
                {
                    b.Navigation("CreatedWorkouts");
                });

            modelBuilder.Entity("LiftingDome.Models.WorkoutCategory", b =>
                {
                    b.Navigation("Workouts");
                });
#pragma warning restore 612, 618
        }
    }
}
