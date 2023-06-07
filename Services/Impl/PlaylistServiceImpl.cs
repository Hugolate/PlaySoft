using PlaySoftBeta.DTOs;
using PlaySoftBeta.Models;
using PlaySoftBeta.Repository;


namespace PlaySoftBeta.Services;

public class PlaylistServiceImpl : IPLaylistService
{
    private readonly IPlaylistLinesRepository _playlistLinesRepository;
    private readonly IPLaylistRepository _pLaylistRepository;
    private readonly ILibraryRepository _libraryRepository;

    private readonly ILogger<PlaylistServiceImpl> _logger;

    public PlaylistServiceImpl(IPLaylistRepository pLaylistRepository, ILibraryRepository libraryRepository, IPlaylistLinesRepository playlistLinesRepository, ILogger<PlaylistServiceImpl> logger)
    {
        _playlistLinesRepository = playlistLinesRepository;
        _pLaylistRepository = pLaylistRepository;
        _libraryRepository = libraryRepository;
        _logger = logger;
    }

    public bool CreatePlaylist(PlaylistDTO playlist)
    {
        try
        {
            var platlistID = _pLaylistRepository.CreatePlaylist(playlist);

            _libraryRepository.NewLine(playlist.userUKID, platlistID);
            _libraryRepository.Save();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(this.GetType().Name, e, "Error on playlist post");
            return false;
        }
    }

    public bool DeletePlaylist(int playlistID)
    {
        try
        {
            _pLaylistRepository.DeletePlaylist(playlistID);
            _pLaylistRepository.Save();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(this.GetType().Name, e, "Error on delete");
            return false;
        }
    }

    public bool EditPLaylist(EditPLaylistDTO editPLaylistDTO)
    {
        try
        {
            _pLaylistRepository.EditPLaylist(editPLaylistDTO);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(this.GetType().Name, e, "Error on playlist edit");
            return false;
        }
    }

    public List<SongIDSongOutDTO> GetSongsId(int playlistID, string? orderKey, string? order)
    {
        try
        {
            return _playlistLinesRepository.GetSongsId(playlistID, orderKey, order);
        }
        catch (Exception e)
        {
            _logger.LogError(this.GetType().Name, e, "Error get plylist songs");
            return null;
        }
    }
    public bool AddSongToPlaylist(PlaylistLinesDTO playlistLinesDTO)
    {
        try
        {
            _playlistLinesRepository.AddSong(playlistLinesDTO);
            _playlistLinesRepository.Save();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(this.GetType().Name, e, "Error add song to playlist");
            return false;
        }
    }

}
