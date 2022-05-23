using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hamster>().HasData(
                new Hamster
                {
                    Id = 1,
                    Name = "Gregory",
                    Age = 2,
                    FavFood = "Peanuts",
                    FavThing = "Wheel",
                    ImgName = "/Content/images/savedImages/hamster-1.jpg",
                    Wins = 0,
                    Losses = 0,
                    Games = 0

                },
                new Hamster
                {
                    Id = 2,
                    Name = "Mr Smith",
                    Age = 2,
                    FavFood = "Seeds",
                    FavThing = "Water bottle",
                    ImgName = "/Content/images/savedImages/hamster-2.jpg",
                    Wins = 0,
                    Losses = 0,
                    Games = 0

                },
                new Hamster
                {
                    Id = 3,
                    Name = "Valeria",
                    Age = 1,
                    FavFood = "Bacon",
                    FavThing = "Corner",
                    ImgName = "/Content/images/savedImages/hamster-3.jpg",
                    Wins = 0,
                    Losses = 0,
                    Games = 0

                },
                new Hamster
                {
                    Id = 4,
                    Name = "Schrödinger",
                    Age = 2,
                    FavFood = "Salad",
                    FavThing = "Sleeping",
                    ImgName = "/Content/images/savedImages/hamster-4.jpg",
                    Wins = 0,
                    Losses = 0,
                    Games = 0

                },
                new Hamster
                {
                    Id = 5,
                    Name = "Menlo",
                    Age = 1,
                    FavFood = "Carrot",
                    FavThing = "Walking",
                    ImgName = "/Content/images/savedImages/hamster-5.jpg",
                    Wins = 0,
                    Losses = 0,
                    Games = 0

                });
        }

        public DbSet<Hamster> Hamsters { get; set; }
        public DbSet<HamsterGame> Hamsters_Games { get; set; }
        public DbSet<Game> Games { get; set; }


    }
}
