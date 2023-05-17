using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface IAlbumRepository
{
    void PostAlbum(AlbumInDTO albumInDTO);
    AlbumOutDTO GetAlbumBySpotifyID(string spotifyAlbumID);
    void Save();
}
