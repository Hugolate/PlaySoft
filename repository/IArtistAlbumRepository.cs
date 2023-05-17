using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface IArtistAlbumRepository
{
    void AddAlbumToArtist(int artistID, int albumID);
    void Save();
}
