﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server_dotnet_fitnessapp.Context;

#nullable disable

namespace server_dotnet_fitnessapp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230426021814_CollectionToList")]
    partial class CollectionToList
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Address", b =>
                {
                    b.Property<Guid>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Cart", b =>
                {
                    b.Property<Guid>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CartId");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Coach", b =>
                {
                    b.Property<Guid>("CoachId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("profilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CoachId");

                    b.HasIndex("AddressId");

                    b.HasIndex("PersonId");

                    b.HasIndex("UserId");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Location", b =>
                {
                    b.Property<Guid>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.HasIndex("AddressId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Membership", b =>
                {
                    b.Property<Guid>("MembershipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MembershipTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("MembershipId");

                    b.HasIndex("MembershipTypeId");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.MembershipType", b =>
                {
                    b.Property<Guid>("MembershipTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Description")
                        .HasColumnType("int");

                    b.Property<bool>("IsRecurring")
                        .HasColumnType("bit");

                    b.HasKey("MembershipTypeId");

                    b.ToTable("MembershipTypes");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Person", b =>
                {
                    b.Property<Guid>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("AddressId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CartId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.HasIndex("PersonId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.UserWorkout", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "WorkoutId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("UserWorkouts");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Workout", b =>
                {
                    b.Property<Guid>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<Guid>("CoachId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("WorkoutId");

                    b.HasIndex("CoachId");

                    b.HasIndex("LocationId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Cart", b =>
                {
                    b.HasOne("server_dotnet_fitnessapp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Coach", b =>
                {
                    b.HasOne("server_dotnet_fitnessapp.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("server_dotnet_fitnessapp.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("server_dotnet_fitnessapp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Person");

                    b.Navigation("User");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Location", b =>
                {
                    b.HasOne("server_dotnet_fitnessapp.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Membership", b =>
                {
                    b.HasOne("server_dotnet_fitnessapp.Models.MembershipType", "MembershipType")
                        .WithMany()
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MembershipType");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Person", b =>
                {
                    b.HasOne("server_dotnet_fitnessapp.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Address");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Product", b =>
                {
                    b.HasOne("server_dotnet_fitnessapp.Models.Cart", null)
                        .WithMany("Products")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.User", b =>
                {
                    b.HasOne("server_dotnet_fitnessapp.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.UserWorkout", b =>
                {
                    b.HasOne("server_dotnet_fitnessapp.Models.User", "User")
                        .WithMany("UserWorkouts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("server_dotnet_fitnessapp.Models.Workout", "Workout")
                        .WithMany("UserWorkouts")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Workout", b =>
                {
                    b.HasOne("server_dotnet_fitnessapp.Models.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("server_dotnet_fitnessapp.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Cart", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.User", b =>
                {
                    b.Navigation("UserWorkouts");
                });

            modelBuilder.Entity("server_dotnet_fitnessapp.Models.Workout", b =>
                {
                    b.Navigation("UserWorkouts");
                });
#pragma warning restore 612, 618
        }
    }
}
