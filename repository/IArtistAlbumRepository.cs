using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface IArtistAlbumRepository
{
    void AddAlbumToArtist(int artistID, int albumID);
    bool CheckIfExist(int artistID, int albumID);
    List<AlbumOutDTO> GetAlbumByArtistID(int artistID);
    bool getLineByAlbumID(int albumID);
    void Save();
}
