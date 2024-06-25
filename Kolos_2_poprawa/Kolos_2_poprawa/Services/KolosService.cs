using Kolos_2_poprawa.Data;

namespace Kolos_2_poprawa.Services;

public class KolosService : IKolosService
{
    private readonly KolosContext _context;

    public KolosService(KolosContext context)
    {
        _context = context;
    }
}