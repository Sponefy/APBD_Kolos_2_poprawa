using Kolos_1_poprawa.Dtos;
using Kolos_2_poprawa.Data;
using Kolos_2_poprawa.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolos_2_poprawa.Services;

public class RentalService : IRentalService
{
    private readonly RentalContext _context;

    public RentalService(RentalContext context)
    {
        _context = context;
    }

    public async Task<ClientDto?> GetClient(int clientId)
    {
        var result = await _context.Clients
            .Where(c => c.Id == clientId)
            .Select(c => new ClientDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = c.Address,

                Rentals = c.rentals.Select(r => new RentalDto
                {
                    Vin = _context.Cars.Where(car => car.Id == r.CarId).Select(car => car.VIN).FirstOrDefault(),
                    Color = _context.Cars
                        .Where(car => car.Id == r.CarId)
                        .Join(_context.Colors,
                            car => car.ColorId,
                            color => color.Id,
                            (car, color) => color.Name)
                        .FirstOrDefault(),
                    Model = _context.Cars
                        .Where(car => car.Id == r.CarId)
                        .Join(_context.Models,
                            car => car.ModelId,
                            Model => Model.Id,
                            (car, model) => model.Name)
                        .FirstOrDefault(),
                    DateFrom = r.DateFrom,
                    DateTo = r.DateTo,
                    TotalPrice = r.TotalPrice
                })
            }).FirstOrDefaultAsync();

        return result;
    }

    public async Task<int> AddRental(AddRentalDto rentalDto)
    {
        var car = _context.Cars.FirstOrDefault(c => c.Id == rentalDto.CarID);
        
        if (car == null)
        {
            return await Task.FromResult(0);
        }
        
        var client = new Client{
            FirstName = rentalDto.Client.FirstName,
            LastName = rentalDto.Client.LastName,
            Address = rentalDto.Client.Address
        };
        
        _context.Clients.Add(client);

        await _context.SaveChangesAsync();
        
        var rental = new CarRental
        {
            ClientId = client.Id,
            CarId = rentalDto.CarID,
            DateFrom = rentalDto.DateFrom,
            DateTo = rentalDto.DateTo,
            TotalPrice = (rentalDto.DateTo - rentalDto.DateFrom).Days * car.PricePerDay,
            Discount = null
        };
        
        _context.CarRentals.Add(rental);

        await _context.SaveChangesAsync();

        return await Task.FromResult(1);
    }
}