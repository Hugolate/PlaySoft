using PlaySoftBeta.Models;
using PlaySoftBeta.Repository;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Services;


public class UserServiceImpl : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserServiceImpl> _logger;

    public UserServiceImpl(IUserRepository userRepository, ILogger<UserServiceImpl> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
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
