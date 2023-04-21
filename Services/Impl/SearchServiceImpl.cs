using PlaySoftBeta.DTOs;
using PlaySoftBeta.Models;
using PlaySoftBeta.Repository;
using SpotifyAPI.Web;

namespace PlaySoftBeta.Services;

public class SearchServiceImpl : ISearchService
{
    private readonly IUserRepository _userRepository;
    private readonly ISongRepository _songRpository;
    private readonly ILogger<SearchServiceImpl> _logger;
    private readonly ISpotifyClient _spotify;

    public SearchServiceImpl(IUserRepository userRepository, ISongRepository songRepository, ILogger<SearchServiceImpl> logger, ISpotifyClient spotify)
    {
        _userRepository = userRepository;
        _songRpository = songRepository;
        _logger = logger;
        _spotify = spotify;
    }

    public Task<SearchResponse> SearchByName(string query)
    {

        return _spotify.Search.Item((new SearchRequest(SearchRequest.Types.Track, query)));

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
