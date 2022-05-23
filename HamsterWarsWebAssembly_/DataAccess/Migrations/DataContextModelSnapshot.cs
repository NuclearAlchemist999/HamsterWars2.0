﻿// <auto-generated />
using System;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HamsterWarsWebAssembly.Shared.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("HamsterWarsWebAssembly.Shared.Models.Hamster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FavFood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavThing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Games")
                        .HasColumnType("int");

                    b.Property<string>("ImgName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Hamsters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 2,
                            FavFood = "Peanuts",
                            FavThing = "Wheel",
                            Games = 0,
                            ImgName = "/Content/images/savedImages/hamster-1.jpg",
                            Losses = 0,
                            Name = "Gregory",
                            Wins = 0
                        },
                        new
                        {
                            Id = 2,
                            Age = 2,
                            FavFood = "Seeds",
                            FavThing = "Water bottle",
                            Games = 0,
                            ImgName = "/Content/images/savedImages/hamster-2.jpg",
                            Losses = 0,
                            Name = "Mr Smith",
                            Wins = 0
                        },
                        new
                        {
                            Id = 3,
                            Age = 1,
                            FavFood = "Bacon",
                            FavThing = "Corner",
                            Games = 0,
                            ImgName = "/Content/images/savedImages/hamster-3.jpg",
                            Losses = 0,
                            Name = "Valeria",
                            Wins = 0
                        },
                        new
                        {
                            Id = 4,
                            Age = 2,
                            FavFood = "Salad",
                            FavThing = "Sleeping",
                            Games = 0,
                            ImgName = "/Content/images/savedImages/hamster-4.jpg",
                            Losses = 0,
                            Name = "Schrödinger",
                            Wins = 0
                        },
                        new
                        {
                            Id = 5,
                            Age = 1,
                            FavFood = "Carrot",
                            FavThing = "Walking",
                            Games = 0,
                            ImgName = "/Content/images/savedImages/hamster-5.jpg",
                            Losses = 0,
                            Name = "Menlo",
                            Wins = 0
                        });
                });

            modelBuilder.Entity("HamsterWarsWebAssembly.Shared.Models.HamsterGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("HamsterId")
                        .HasColumnType("int");

                    b.Property<string>("WinStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("HamsterId");

                    b.ToTable("Hamsters_Games");
                });

            modelBuilder.Entity("HamsterWarsWebAssembly.Shared.Models.HamsterGame", b =>
                {
                    b.HasOne("HamsterWarsWebAssembly.Shared.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HamsterWarsWebAssembly.Shared.Models.Hamster", "Hamster")
                        .WithMany()
                        .HasForeignKey("HamsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Hamster");
                });
#pragma warning restore 612, 618
        }
    }
}
