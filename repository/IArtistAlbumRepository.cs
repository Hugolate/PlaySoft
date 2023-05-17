using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface IArtistAlbumRepository
{
    void AddAlbumToArtist(ArtistInDTO artistInDTO, AlbumInDTO albumInDTO);
    void Save();
}
