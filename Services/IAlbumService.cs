using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Services;

public interface IAlbumService
{
    public bool DeleteAlbum(int artistID);
    public List<AlbumOutDTO> GetAllAlbums(int pageNumber);
    public int CountAlbums();
}
