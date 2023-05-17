using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
using PlaySoftBeta.Repository;


namespace PlaySoftBeta.Services;

public class SongServiceImpl : ISongService
{

    private readonly ISongRepository _songRepository;
    private readonly IArtistRepository _artistRepository; 
    private readonly IAlbumRepository _albumRepository;
    private readonly IArtistAlbumRepository _artistAlbumRepository;
    private readonly IArtistSongRepository _artistSongRepository;
    private readonly ILogger<SongServiceImpl> _logger;

    public SongServiceImpl(ISongRepository songRepository,IArtistSongRepository artistSongRepository, IAlbumRepository albumRepository, IArtistRepository artistRepository,IArtistAlbumRepository artistAlbumRepository, ILogger<SongServiceImpl> logger)
    {
        _songRepository = songRepository;
        _albumRepository = albumRepository;
        _artistRepository = artistRepository;
        _artistSongRepository = artistSongRepository;
        _artistAlbumRepository = artistAlbumRepository;
        _logger = logger;
    }

    public SongOutDTO GetSong(int songID)
    {
        try
        {
            return _songRepository.GetSong(songID);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error get song");
            throw;
        }
    }
    public bool NewSong(SongInDTO songInDTO, ArtistInDTO artistInDTO, AlbumInDTO albumInDTO)
    {

        try
        {
            _songRepository.PostSong(songInDTO);
            _albumRepository.PostAlbum(albumInDTO);
            _artistRepository.PostArtist(artistInDTO);
    
            /*var album = _albumRepository.GetAlbumBySpotifyID(albumInDTO.spotifyAlbumID);
            var artist = _artistRepository.GetArtistBySpotifyID(artistInDTO.spotifyArtistID);
            var song = _songRepository.GetSongBySpotifyID(artistInDTO.spotifyArtistID);
*/
            _artistAlbumRepository.AddAlbumToArtist(artistInDTO, albumInDTO);
            _artistSongRepository.AddSongToArtist(artistInDTO, songInDTO);
            return true;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}