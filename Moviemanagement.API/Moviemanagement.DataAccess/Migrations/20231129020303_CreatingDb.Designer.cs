﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Moviemanagement.DataAccess.Context;

#nullable disable

namespace Moviemanagement.DataAccess.Migrations
{
    [DbContext(typeof(MovieManagementDbContext))]
    [Migration("20231129020303_CreatingDb")]
    partial class CreatingDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("GenreId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("Moviemanagement.Domain.Entities.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Chuck",
                            LastName = "Norris"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Jane",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Van",
                            LastName = "Damme"
                        });
                });

            modelBuilder.Entity("Moviemanagement.Domain.Entities.Biography", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ActorId")
                        .IsUnique();

                    b.ToTable("Biographys");
                });

            modelBuilder.Entity("Moviemanagement.Domain.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("Moviemanagement.Domain.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActorId = 1,
                            Description = "Box Office we coming",
                            Name = "Wakanda Forever"
                        },
                        new
                        {
                            Id = 2,
                            ActorId = 2,
                            Description = "Box Office we coming",
                            Name = "Wakanda Forever"
                        },
                        new
                        {
                            Id = 3,
                            ActorId = 1,
                            Description = "Sky Scrappers be warned",
                            Name = "Spiderman"
                        },
                        new
                        {
                            Id = 4,
                            ActorId = 3,
                            Description = "Blue or Red Pill",
                            Name = "Matrix"
                        });
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("Moviemanagement.Domain.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Moviemanagement.Domain.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Moviemanagement.Domain.Entities.Biography", b =>
                {
                    b.HasOne("Moviemanagement.Domain.Entities.Actor", "Actor")
                        .WithOne("Biography")
                        .HasForeignKey("Moviemanagement.Domain.Entities.Biography", "ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");
                });

            modelBuilder.Entity("Moviemanagement.Domain.Entities.Movie", b =>
                {
                    b.HasOne("Moviemanagement.Domain.Entities.Actor", "Actor")
                        .WithMany("Movies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");
                });

            modelBuilder.Entity("Moviemanagement.Domain.Entities.Actor", b =>
                {
                    b.Navigation("Biography");

                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
