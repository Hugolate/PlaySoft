using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface ISongRepository
{

    void DeleteSong(int songID);
    SongOutDTO GetSong(int songID);

    List<SongOutDTO> GetAllSongs();
    List<SearchSongOutDTO> GetSongListByName(string songName);
    void PostSong(SongInDTO SongOutDTO);
    void Save();
    SongOutDTO GetSongBySpotifyID(string spotifyArtistID);
}
