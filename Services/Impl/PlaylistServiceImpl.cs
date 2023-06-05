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

    public List<SongIDSongOutDTO> GetSongsId(int playlistID, string? orderKey, string? order)
    {
        try
        {
            return _playlistLinesRepository.GetSongsId(playlistID, orderKey, order);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error get playlist songs");
            throw;
        }
    }
    public void AddSongToPlaylist(PlaylistLinesDTO playlistLinesDTO)
    {
        _playlistLinesRepository.AddSong(playlistLinesDTO);
        _playlistLinesRepository.Save();
    }


    public void AddPlaylistToLibrary(LibraryDTO libraryDTO)
    {
        if (libraryDTO.playlistID != null)
        {

            _libraryRepository.NewLine(libraryDTO.userID, (int)libraryDTO.playlistID);
            _libraryRepository.Save();
        }
    }
}
