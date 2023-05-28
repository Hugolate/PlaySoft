using PlaySoftBeta.DTOs;
using PlaySoftBeta.Repository;


namespace PlaySoftBeta.Services;

public class ArtistServiceImpl : IArtistService
{

    private readonly IArtistRepository _artistRepository;

    private readonly ILogger<ArtistServiceImpl> _logger;

    public ArtistServiceImpl(IArtistRepository artistRepository, ILogger<ArtistServiceImpl> logger)
    {
        _artistRepository = artistRepository;
        _logger = logger;
    }

    public bool DeleteArtist(int artistID)
    {
        throw new NotImplementedException();
    }

    public List<ArtistOutDTO> GetAllArtists()
    {
        return _artistRepository.GetAllArtists();
    }
}
