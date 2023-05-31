using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface IArtistRepository
{
    void PostArtist(ArtistInDTO artistInDTO);
    List<ArtistOutDTO> GetAllArtists(int pageNumber);
    ArtistOutDTO GetArtistBySpotifyID(string spotifyArtistID);
    void DeleteArtist(int artistID);
    int CountArtists();
    void Save();
}
