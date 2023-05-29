using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Services;

public interface IUserService
{
    UserDTO GetUser(int ukid);
    bool DeleteUser(int playlistID);
}