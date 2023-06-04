using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface IPLaylistRepository
{
    int CreatePlaylist (PlaylistDTO playlist);
    void DeletePlaylist (int playlistID);
    
    void EditPLaylist(EditPLaylistDTO editPLaylistDTO);
    List<PlaylistDTO> getOwnPlaylist(int userUKID);
    void Save();
}
