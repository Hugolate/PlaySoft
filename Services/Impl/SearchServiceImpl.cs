using PlaySoftBeta.DTOs;
using PlaySoftBeta.Models;
using PlaySoftBeta.Repository;


namespace PlaySoftBeta.Services;

public class SearchServiceImpl : ISearchService
{
    private readonly IUserRepository _userRepository;
    private readonly ISongRepository _songRpository;
    private readonly ILogger<SearchServiceImpl> _logger;


    public SearchServiceImpl(IUserRepository userRepository, ISongRepository songRepository, ILogger<SearchServiceImpl> logger)
    {
        _userRepository = userRepository;
        _songRpository = songRepository;
        _logger = logger;
    }

    public SearchDTO SearchByName(string query)
    {
        try
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

    }
}
