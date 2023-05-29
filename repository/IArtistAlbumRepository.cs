using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface IArtistAlbumRepository
{
    void DeleteArtistAlbum(int albumID);
    void AddAlbumToArtist(int artistID, int albumID);
    bool CheckIfExist(int artistID, int albumID);
    void Save();
}
