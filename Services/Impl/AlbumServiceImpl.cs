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

    public bool DeleteAlbum(int artistID)
    {
        try
        {
            _artistAlbumRepository.DeleteArtistAlbum(artistID);
            _artistAlbumRepository.Save();
            _albumRepository.DeleteAlbum(artistID);
            _artistAlbumRepository.Save();
            return true;
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public List<AlbumOutDTO> GetAllAlbums()
    {
        return _albumRepository.GetAllAlbums();
    }
}
