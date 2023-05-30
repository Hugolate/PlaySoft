using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Services;

public interface ISongService
{
    public SongOutDTO GetSong(int songID);
    public List<SongOutDTO> GetAllSongs(int pageNumber);
    public bool DeleteSong(int songID);
    public int NewSong(SongInDTO SongOutDTO, ArtistInDTO ArtistInDTO, AlbumInDTO AlbumInDTO);
    public int CountSongs();
}