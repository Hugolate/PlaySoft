using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface IArtistRepository
{
    void PostArtist(ArtistInDTO artistInDTO);
    ArtistOutDTO GetArtistBySpotifyID(string spotifyArtistID);
    void Save();
}
