using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface ISongRepository
{
    SongOutDTO GetSong(int songID);
    List<SearchSongOutDTO> GetSongListByName(string songName);
    void PostSong(SongInDTO SongOutDTO);
    SongOutDTO GetSongBySpotifyID(string spotifyArtistID);
}
