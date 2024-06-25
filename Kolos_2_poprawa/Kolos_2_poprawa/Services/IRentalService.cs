using Kolos_1_poprawa.Dtos;

namespace Kolos_2_poprawa.Services;

public interface IRentalService
{
    Task<ClientDto?> GetClient(int clientId);
    Task<int> AddRental(AddRentalDto rentalDto);
}