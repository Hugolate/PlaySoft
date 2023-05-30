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

    public int CountArtists()
    {
        return _artistRepository.CountArtists();
    }

    public bool DeleteArtist(int artistID)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public List<ArtistOutDTO> GetAllArtists(int pageNumber)
    {
        try
        {
            return _artistRepository.GetAllArtists(pageNumber);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}
