using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface IArtistRepository
{
    void PostArtist(ArtistInDTO artistInDTO);
    void DeleteArtist(int artistID);
    List<ArtistOutDTO> GetAllArtists();
    ArtistOutDTO GetArtistBySpotifyID(string spotifyArtistID);
    void Save();
}
