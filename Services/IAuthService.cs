using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Services;

public interface IAuthService
{
    public int Login(AuthLoginInDTO user);
    public bool Register(AuhtRegisterUserDTO user);
}