using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface IArtistSongRepository
{
    void DeleteArtistSong(int songID);
    void AddSongToArtist(int artistID, int songID);
    bool CheckIfExist(int artistID, int songID);
    void Save();
}
