using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface ISongRepository
{
    SongDTO GetSong(int songID);
    List<SearchSongDTO> GetSongListByName(string songName);

 }
