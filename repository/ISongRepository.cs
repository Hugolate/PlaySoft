using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface ISongRepository
{

    void DeleteSong(int songID);
    SongOutDTO GetSong(int songID);

    List<SongOutDTO> GetAllSongs(int pageNumber);
    List<SearchSongOutDTO> GetSongListByName(string songName);
    void PostSong(SongInDTO SongOutDTO);
    SongOutDTO GetSongBySpotifyID(string spotifyArtistID);
    int CountSongs();
    void Save();
}
