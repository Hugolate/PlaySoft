using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface IArtistSongRepository
{
    void AddSongToArtist(ArtistInDTO artistInDTO, SongInDTO songInDTO);
    void Save();
}
