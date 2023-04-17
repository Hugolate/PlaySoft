using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Services;

public interface IAuthService
{
    public AuthLoginOutDTO Login(AuthLoginInDTO user);
    public bool Register(AuhtRegisterUserDTO user);
}