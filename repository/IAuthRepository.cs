using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface IAuthRepositoy
{
    AuthLoginOutDTO GetUserByEmail(String userEmail);
    bool CheckEmail(String userEmail);
    void RegisterUser(AuhtRegisterUserDTO user);
    void Save();
}
