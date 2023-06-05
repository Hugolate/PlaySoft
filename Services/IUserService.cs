using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Services;

public interface IUserService
{
    public UserLibraryPlaylistsDTO GetUser(int ukid);
    public bool DeleteUser(int playlistID);
    

}