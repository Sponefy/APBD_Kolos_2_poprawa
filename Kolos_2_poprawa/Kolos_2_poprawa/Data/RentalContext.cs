using System.Drawing;
using Kolos_2_poprawa.Models;
using Microsoft.EntityFrameworkCore;
using Color = Kolos_2_poprawa.Models.Color;

namespace Kolos_2_poprawa.Data;

public class RentalContext : DbContext
{
    public RentalContext(DbContextOptions<RentalContext> options) : base(options)
    {
    }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarRental> CarRentals { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Color> Colors { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var foreignKey in entityType.GetForeignKeys())
            {
                
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        modelBuilder.Entity<Client>()
            .HasData(
                new Client
                {
                    Id = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Address = "Koszykowa 63"
                },
                new Client
                {
                    Id = 2,
                    FirstName = "Anna",
                    LastName = "Nowa",
                    Address = "Złota 44"
                });

        modelBuilder.Entity<Color>()
            .HasData(
                new Color
                {
                    Id = 1,
                    Name = "red"
                },new Color
                {
                    Id = 2,
                    Name = "black"
                },new Color
                {
                    Id = 3,
                    Name = "white"
                });
        
        modelBuilder.Entity<Model>()
            .HasData(
                new Model
                {
                    Id = 1,
                    Name = "Mazda"
                },new Model
                {
                    Id = 2,
                    Name = "Toyota"
                },new Model
                {
                    Id = 3,
                    Name = "Skoda"
                },new Model
                {
                    Id = 4,
                    Name = "Ford"
                });

        modelBuilder.Entity<Car>()
            .HasData(
                new Car
                {
                    Id = 1,
                    VIN = "2D4HN11EX9R686008",
                    Name = "Toyota Yaris",
                    Seats = 5,
                    PricePerDay = 120,
                    ModelId = 2,
                    ColorId = 3
                },new Car
                {
                    Id = 2,
                    VIN = "JTDBR32E630013672",
                    Name = "Skoda Fabia Estate",
                    Seats = 5,
                    PricePerDay = 170,
                    ModelId = 3,
                    ColorId = 2
                });
        
        modelBuilder.Entity<CarRental>()
            .HasData(
                new CarRental
                {
                    Id = 1,
                    ClientId = 1,
                    CarId = 1,
                    DateFrom = DateTime.Now,
                    DateTo = DateTime.Now.AddDays(5),
                    TotalPrice = 480
                },new CarRental
                {
                    Id = 2,
                    ClientId = 1,
                    CarId = 1,
                    DateFrom = DateTime.Now,
                    DateTo = DateTime.Now.AddDays(5),
                    TotalPrice = 240,
                    Discount = 50
                },new CarRental
                {
                    Id = 3,
                    ClientId = 1,
                    CarId = 2,
                    DateFrom = DateTime.Now,
                    DateTo = DateTime.Now.AddDays(5),
                    TotalPrice = 1700
                });

    }
}