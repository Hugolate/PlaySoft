using PlaySoftBeta.Models;
using PlaySoftBeta.Repository;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Services;

public class AuthServiceImpl : IAuthService
{
    private readonly IAuthRepositoy _authRepository;
    private readonly ILogger<AuthServiceImpl> _logger;

    public AuthServiceImpl(IAuthRepositoy authRepository, ILogger<AuthServiceImpl> logger)
    {
        _authRepository = authRepository;
        _logger = logger;
    }

    public int Login(AuthLoginInDTO authLoginInDTO)
    {
        try
        {
            var authLoginOutDTO = _authRepository.GetUserByEmail(authLoginInDTO.email);
            if (authLoginOutDTO != null)
            {
                if (authLoginOutDTO.password.Equals(authLoginInDTO.password))
                {
                    return authLoginOutDTO.UKID;
                }
            }
            return 0;
        }
        catch (Exception e)
        {
            _logger.LogError(this.GetType().Name, e, "Error login");
            return -1;
        }

    }

    public bool Register(AuhtRegisterUserDTO auhtRegisterUserDTO)
    {
        try
        {
            if (!_authRepository.CheckEmail(auhtRegisterUserDTO.email))
            {
                _authRepository.RegisterUser(auhtRegisterUserDTO);
                _authRepository.Save();
                return true;
            }
            return false;
        }
        catch (Exception e)
        {
            _logger.LogError(this.GetType().Name, e, "Error register");
            throw;
        }

    }
}
