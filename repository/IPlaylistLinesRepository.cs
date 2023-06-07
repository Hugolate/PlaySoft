using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface IPlaylistLinesRepository
{

    void DeleteLine(PlaylistLinesDTO line);
    void AddSong(PlaylistLinesDTO playlistLinesDTO);
    List<SongIDSongOutDTO> GetSongsId(int playlistID, string orderKey, string order);
    void Save();
}
