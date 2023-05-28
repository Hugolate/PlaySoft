using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Services;

public interface IArtistService
{

    public bool DeleteArtist(int artistID);
    public List<ArtistOutDTO> GetAllArtists();

}
