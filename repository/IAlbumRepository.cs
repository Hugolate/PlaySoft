using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface IAlbumRepository
{
    void DeleteAlbum(int albumID);
    void PostAlbum(AlbumInDTO albumInDTO);
    List<AlbumOutDTO> GetAllAlbums(int pageNumber);
    AlbumOutDTO GetAlbumBySpotifyID(string spotifyAlbumID);
    int CountAlbums();
    void Save();
}
