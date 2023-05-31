using PlaySoftBeta.DTOs;
using PlaySoftBeta.Repository;


namespace PlaySoftBeta.Services;

public class ArtistServiceImpl : IArtistService
{

    private readonly IArtistRepository _artistRepository;
    private readonly IArtistAlbumRepository _artistAlbumRepository;
    private readonly IAlbumRepository _albumRepository;
    private readonly ILogger<ArtistServiceImpl> _logger;

    public ArtistServiceImpl(IArtistRepository artistRepository, ILogger<ArtistServiceImpl> logger, IArtistAlbumRepository artistAlbumRepository, IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
        _artistRepository = artistRepository;
        _artistAlbumRepository = artistAlbumRepository;
        _logger = logger;
    }

    public int CountArtists()
    {
        return _artistRepository.CountArtists();
    }

    public bool DeleteArtist(int artistID)
    {
        try
        {
            var albumList = _artistAlbumRepository.GetAlbumByArtistID(artistID);
            _artistRepository.DeleteArtist(artistID);
            _artistRepository.Save();
            if (albumList.Any())
            {
                foreach (var album in albumList)
                {
                    if (_artistAlbumRepository.getLineByAlbumID(album.albumID))
                    {
                        _albumRepository.DeleteAlbum(album.albumID);
                    }
                }
            }
            _albumRepository.Save();
            return true;
        }
        catch (System.Exception)
        {

            throw;
        }

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
