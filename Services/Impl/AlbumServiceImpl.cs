using PlaySoftBeta.DTOs;
using PlaySoftBeta.Repository;


namespace PlaySoftBeta.Services;

public class AlbumServiceImpl : IAlbumService
{

    private readonly IAlbumRepository _albumRepository;

    private readonly IArtistAlbumRepository _artistAlbumRepository;
    private readonly ILogger<AlbumServiceImpl> _logger;

    public AlbumServiceImpl(IAlbumRepository albumRepository, IArtistAlbumRepository artistAlbumRepository, ILogger<AlbumServiceImpl> logger)
    {
        _albumRepository = albumRepository;
        _artistAlbumRepository = artistAlbumRepository;
        _logger = logger;
    }

    public int CountAlbums()
    {
        try
        {
            return _albumRepository.CountAlbums();
        }
        catch (Exception e)
        {
            _logger.LogError(this.GetType().Name, e, "Count error");
            return -1;
        }
    }
    public bool DeleteAlbum(int albumID)
    {
        try
        {
            _albumRepository.DeleteAlbum(albumID);
            _artistAlbumRepository.Save();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(this.GetType().Name, e, "Error on delete");
            return false;
        }
    }

    public List<AlbumOutDTO> GetAllAlbums(int pageNumber)
    {
        try
        {
            return _albumRepository.GetAllAlbums(pageNumber);
        }
        catch (Exception e)
        {
            _logger.LogError(this.GetType().Name, e, "Error getAll");
            return null;
        }
    }
}
