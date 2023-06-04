using PlaySoftBeta.Models;
using PlaySoftBeta.Repository;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Services;


public class UserServiceImpl : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPlaylistLinesRepository _playlistLinesRepository;
    private readonly IPLaylistRepository _pLaylistRepository;
    private readonly ILibraryRepository _libraryRepository;
    private readonly ILogger<UserServiceImpl> _logger;

    public UserServiceImpl(IUserRepository userRepository, ILogger<UserServiceImpl> logger, IPlaylistLinesRepository playlistLinesRepository,
                            IPLaylistRepository playlistRepository, ILibraryRepository libraryRepository)
    {
        _userRepository = userRepository;
        _logger = logger;
        _playlistLinesRepository = playlistLinesRepository;
        _pLaylistRepository = playlistRepository;
        _libraryRepository = libraryRepository;
    }
    public bool DeleteUser(int userID)
    {
        try
        {
            _userRepository.DeleteUser(userID);
            _userRepository.Save();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error deleting playlist");
            throw;
        }
    }
    public UserLibraryPlaylistsDTO GetUser(int ukid)
    {
        try
        {
            var user = _userRepository.GetUser(ukid);
            foreach (var item in user.Libraries)
            {
                if (item.Playlist.userUKID == ukid)
                {
                    item.Playlist.owner = true;
                }
                else
                {
                    item.Playlist.owner = false;
                }
            }
            return user;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error get user");
            throw;
        }
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
