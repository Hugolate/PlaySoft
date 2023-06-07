using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Services;

public interface IPLaylistService
{
    public bool CreatePlaylist(PlaylistDTO playlist);

    public bool DeleteSongFromPlaylist(PlaylistLinesDTO line);
    public bool DeletePlaylist(int playlistID);
    public bool EditPLaylist(EditPLaylistDTO editPLaylistDTO);
    public bool AddSongToPlaylist(PlaylistLinesDTO playlistLinesDTO);
    public List<SongIDSongOutDTO> GetSongsId(int playlistID, string orderKey, string order);
}
