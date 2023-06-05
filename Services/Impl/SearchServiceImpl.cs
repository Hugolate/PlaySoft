using PlaySoftBeta.DTOs;
using PlaySoftBeta.Models;
using PlaySoftBeta.Repository;
using SpotifyAPI.Web;

namespace PlaySoftBeta.Services;

public class SearchServiceImpl : ISearchService
{
    private readonly IUserRepository _userRepository;
    private readonly IPLaylistRepository _playlistRepository;
    private readonly ILogger<SearchServiceImpl> _logger;
    private readonly ISpotifyClient _spotify;

    public SearchServiceImpl(ILogger<SearchServiceImpl> logger, ISpotifyClient spotify, IPLaylistRepository playlistRepository)
    {
        _playlistRepository = playlistRepository;
        _logger = logger;
        _spotify = spotify;
    }

    public SearchDTO SearchByName(string query)
    {
        var response = new SearchDTO
        {
            spotifyResponse = _spotify.Search.Item((new SearchRequest(SearchRequest.Types.Track, query))),
            playlist = _playlistRepository.GetPLaylistList(query)
        };
        return response;


        /*try
        {
            var users = _userRepository.GetUserListByUsername(query);
            var songs = _songRpository.GetSongListByName(query);

            var searchDTO = new SearchDTO
            {
                songs = songs,
                users = users,
            };

            return searchDTO;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error search");
            throw;
        }

    }*/

    }
}
