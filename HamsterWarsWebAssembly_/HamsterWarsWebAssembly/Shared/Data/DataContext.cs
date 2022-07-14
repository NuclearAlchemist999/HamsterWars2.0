using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HamsterWarsWebAssembly.Shared.Data
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
                    Name = "Emperor",
                    Age = 2,
                    FavFood = "Peanuts",
                    Loves = "Wheel",
                    ImgName = "/images/hamster-15.jpg",
                    Wins = 0,
                    Losses = 0,
                    Games = 0
                },
                new Hamster
                {
                    Id = 2,
                    Name = "Arcturus",
                    Age = 2,
                    FavFood = "Seeds",
                    Loves = "Water bottle",
                    ImgName = "/images/hamster-25.jpg",
                    Wins = 0,
                    Losses = 0,
                    Games = 0
                },
                new Hamster
                {
                    Id = 3,
                    Name = "Dissection",
                    Age = 1,
                    FavFood = "Bacon",
                    Loves = "Corner",
                    ImgName = "/images/hamster-24.jpg",
                    Wins = 0,
                    Losses = 0,
                    Games = 0
                },
                new Hamster
                {
                    Id = 4,
                    Name = "Urfaust",
                    Age = 2,
                    FavFood = "Salad",
                    Loves = "Sleeping",
                    ImgName = "/images/hamster-14.jpg",
                    Wins = 0,
                    Losses = 0,
                    Games = 0
                },
                new Hamster
                {
                    Id = 5,
                    Name = "Burzum",
                    Age = 1,
                    FavFood = "Carrot",
                    Loves = "Walking",
                    ImgName = "/images/hamster-35.jpg",
                    Wins = 0,
                    Losses = 0,
                    Games = 0
                },
                new Hamster
                {
                    Id = 6,
                    Name = "Morbid Angel",
                    Age = 4,
                    FavFood = "Beans",
                    Loves = "Dominating",
                    ImgName = "/images/hamster-23.jpg",
                    Wins = 0,
                    Losses = 0,
                    Games = 0
                },
                new Hamster
                {
                    Id = 7,
                    Name = "Fleshgod Apocalypse",
                    Age = 2,
                    FavFood = "Meat",
                    Loves = "Biting",
                    ImgName = "/images/hamster-38.jpg",
                    Wins = 0,
                    Losses = 0,
                    Games = 0
                },
                new Hamster
                {
                    Id = 8,
                    Name = "Carcass",
                    Age = 3,
                    FavFood = "Apple",
                    Loves = "Jumping",
                    ImgName = "/images/hamster-40.jpg",
                    Wins = 0,
                    Losses = 0,
                    Games = 0
                });
        }
        public DbSet<Hamster> Hamsters { get; set; }
        public DbSet<HamsterGame> Hamsters_Games { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
