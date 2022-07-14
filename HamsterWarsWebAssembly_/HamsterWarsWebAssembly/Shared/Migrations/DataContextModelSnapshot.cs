﻿// <auto-generated />
using System;
using HamsterWarsWebAssembly.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HamsterWarsWebAssembly.Shared.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Games")
                        .HasColumnType("int");

                    b.Property<string>("ImgName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<string>("Loves")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
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
                            Games = 0,
                            ImgName = "/images/hamster-15.jpg",
                            Losses = 0,
                            Loves = "Wheel",
                            Name = "Emperor",
                            Wins = 0
                        },
                        new
                        {
                            Id = 2,
                            Age = 2,
                            FavFood = "Seeds",
                            Games = 0,
                            ImgName = "/images/hamster-25.jpg",
                            Losses = 0,
                            Loves = "Water bottle",
                            Name = "Arcturus",
                            Wins = 0
                        },
                        new
                        {
                            Id = 3,
                            Age = 1,
                            FavFood = "Bacon",
                            Games = 0,
                            ImgName = "/images/hamster-24.jpg",
                            Losses = 0,
                            Loves = "Corner",
                            Name = "Dissection",
                            Wins = 0
                        },
                        new
                        {
                            Id = 4,
                            Age = 2,
                            FavFood = "Salad",
                            Games = 0,
                            ImgName = "/images/hamster-14.jpg",
                            Losses = 0,
                            Loves = "Sleeping",
                            Name = "Urfaust",
                            Wins = 0
                        },
                        new
                        {
                            Id = 5,
                            Age = 1,
                            FavFood = "Carrot",
                            Games = 0,
                            ImgName = "/images/hamster-35.jpg",
                            Losses = 0,
                            Loves = "Walking",
                            Name = "Burzum",
                            Wins = 0
                        },
                        new
                        {
                            Id = 6,
                            Age = 4,
                            FavFood = "Beans",
                            Games = 0,
                            ImgName = "/images/hamster-23.jpg",
                            Losses = 0,
                            Loves = "Dominating",
                            Name = "Morbid Angel",
                            Wins = 0
                        },
                        new
                        {
                            Id = 7,
                            Age = 2,
                            FavFood = "Meat",
                            Games = 0,
                            ImgName = "/images/hamster-38.jpg",
                            Losses = 0,
                            Loves = "Biting",
                            Name = "Fleshgod Apocalypse",
                            Wins = 0
                        },
                        new
                        {
                            Id = 8,
                            Age = 3,
                            FavFood = "Apple",
                            Games = 0,
                            ImgName = "/images/hamster-40.jpg",
                            Losses = 0,
                            Loves = "Jumping",
                            Name = "Carcass",
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

            modelBuilder.Entity("HamsterWarsWebAssembly.Shared.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
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