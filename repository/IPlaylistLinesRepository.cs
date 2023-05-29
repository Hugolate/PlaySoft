using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface IPlaylistLinesRepository
{

    void AddSong(PlaylistLinesDTO playlistLinesDTO);
    List<SongIDSongOutDTO> GetSongsId(int playlistID, string orderKey, string order);
    void Save();
}
