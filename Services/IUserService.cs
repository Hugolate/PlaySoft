using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Services;

public interface IUserService
{
    public UserDTO GetUser(int ukid);
    public bool DeleteUser(int playlistID);
    
    public void AddPlaylistToLibrary(LibraryDTO libraryDTO);
}