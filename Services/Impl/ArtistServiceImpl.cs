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
        try
        {
            return _artistRepository.CountArtists();

        }
        catch (Exception e)
        {
            _logger.LogError(this.GetType().Name, e, "Error count");
            return -1;
        }
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
        catch (Exception e)
        {
            _logger.LogError(this.GetType().Name, e, "Error getAll");
            return false;
        }

    }

    public List<ArtistOutDTO> GetAllArtists(int pageNumber)
    {
        try
        {
            return _artistRepository.GetAllArtists(pageNumber);
        }
        catch (Exception e)
        {

            _logger.LogError(this.GetType().Name, e, "Error getAll");
            return null;
        }
    }



    public override string? ToString()
    {
        return base.ToString();
    }
}
