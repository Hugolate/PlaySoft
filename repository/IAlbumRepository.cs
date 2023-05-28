using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface IAlbumRepository
{
    void DeleteAlbum(int albumID);
    void PostAlbum(AlbumInDTO albumInDTO);
    List<AlbumOutDTO> GetAllAlbums();
    AlbumOutDTO GetAlbumBySpotifyID(string spotifyAlbumID);
    void Save();
}
