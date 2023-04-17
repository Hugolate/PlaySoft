using PlaySoftBeta.DTOs;
using PlaySoftBeta.Models;
using PlaySoftBeta.Repository;


namespace PlaySoftBeta.Services;

public class PlaylistServiceImpl : IPLaylistService
{
    private readonly IPlaylistLinesRepository _playlistLinesRepository;
    private readonly IPLaylistRepository _pLaylistRepository;

    private readonly ILogger<PlaylistServiceImpl> _logger;

    public PlaylistServiceImpl(IPLaylistRepository pLaylistRepository, IPlaylistLinesRepository playlistLinesRepository, ILogger<PlaylistServiceImpl> logger)
    {
        _playlistLinesRepository = playlistLinesRepository;
        _pLaylistRepository = pLaylistRepository;
        _logger = logger;
    }

    public bool CreatePlaylist(PlaylistDTO playlist)
    {
        try
        {
            _pLaylistRepository.CreatePlaylist(playlist);
            _pLaylistRepository.Save();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error creating playlist");
            throw;
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
            _logger.LogError(e, "Error deleting playlist");
            throw;
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
            _logger.LogError(e, "Error editing playlist");
            throw;
        }
    }

    public List<SongIDSongOutDTO> GetSongsId(int playlistID, string orderKey, string order)
    {
        try
        {
            if (orderKey.Equals("songName") || orderKey.Equals("songID") || orderKey.Equals("duration"))
            {
                return _playlistLinesRepository.GetSongsId(playlistID, orderKey, order);
            }
            return null;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error get playlist songs");
            throw;
        }
    }
}
