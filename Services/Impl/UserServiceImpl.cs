using PlaySoftBeta.Models;
using PlaySoftBeta.Repository;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Services;


public class UserServiceImpl : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPlaylistLinesRepository _playlistLinesRepository;
    private readonly IPLaylistRepository _pLaylistRepository;
    private readonly ILogger<UserServiceImpl> _logger;

    public UserServiceImpl(IUserRepository userRepository, ILogger<UserServiceImpl> logger, IPlaylistLinesRepository playlistLinesRepository, IPLaylistRepository playlistRepository)
    {
        _userRepository = userRepository;
        _logger = logger;
        _playlistLinesRepository = playlistLinesRepository;
        _pLaylistRepository = playlistRepository;
    }
    public bool DeleteUser(int userID)
    {
        try
        {
            var userPlaylists = _userRepository.GetUser(userID).playlists;

            if (userPlaylists.Any() && userPlaylists != null)
            {
                foreach (var playlist in userPlaylists)
                {
                    _pLaylistRepository.DeletePlaylist(playlist.playlistID);
                    _pLaylistRepository.Save();
                }

            }
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
    public UserDTO GetUser(int ukid)
    {
        try
        {
            return _userRepository.GetUser(ukid);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error get user");
            throw;
        }
    }
}
