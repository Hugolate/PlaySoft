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
    private readonly IPlaylistLinesRepository _playlistLinesRepository;
    private readonly ILogger<SongServiceImpl> _logger;

    public SongServiceImpl(ISongRepository songRepository, IArtistSongRepository artistSongRepository, IAlbumRepository albumRepository, IArtistRepository artistRepository,
                             IArtistAlbumRepository artistAlbumRepository, IPlaylistLinesRepository playlistLinesRepository, ILogger<SongServiceImpl> logger)
    {
        _songRepository = songRepository;
        _albumRepository = albumRepository;
        _artistRepository = artistRepository;
        _artistSongRepository = artistSongRepository;
        _artistAlbumRepository = artistAlbumRepository;
        _playlistLinesRepository = playlistLinesRepository;
        _logger = logger;
    }
    public List<SongOutDTO> GetAllSongs()
    {
        try
        {
            return _songRepository.GetAllSongs();
        }
        catch (System.Exception)
        {

            throw;
        }

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

    public bool DeleteSong(int songID)
    {
        try
        {
            _songRepository.DeleteSong(songID);
            _songRepository.Save();
            return true;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
    public int NewSong(SongInDTO songInDTO, ArtistInDTO artistInDTO, AlbumInDTO albumInDTO)
    {

        try
        {
            var album = _albumRepository.GetAlbumBySpotifyID(albumInDTO.spotifyAlbumID);
            var artist = _artistRepository.GetArtistBySpotifyID(artistInDTO.spotifyArtistID);
            var song = _songRepository.GetSongBySpotifyID(songInDTO.spotifySongID);

            if (album == null)
            {
                _albumRepository.PostAlbum(albumInDTO);
                _albumRepository.Save();
                album = _albumRepository.GetAlbumBySpotifyID(albumInDTO.spotifyAlbumID);
            }

            if (artist == null)
            {
                _artistRepository.PostArtist(artistInDTO);
                _artistRepository.Save();
                artist = _artistRepository.GetArtistBySpotifyID(artistInDTO.spotifyArtistID);
            }

            if (song == null)
            {
                songInDTO.AlbumID = album.albumID;
                _songRepository.PostSong(songInDTO);
                _songRepository.Save();
                song = _songRepository.GetSongBySpotifyID(songInDTO.spotifySongID);
            }


            if (!_artistAlbumRepository.CheckIfExist(artist.artistID, album.albumID))
            {
                _artistAlbumRepository.AddAlbumToArtist(artist.artistID, album.albumID);
                _artistAlbumRepository.Save();
            }

            if (!_artistSongRepository.CheckIfExist(artist.artistID, song.songID))
            {
                _artistSongRepository.AddSongToArtist(artist.artistID, song.songID);
                _artistSongRepository.Save();
            }

            return song.songID;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}