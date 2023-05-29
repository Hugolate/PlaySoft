using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Services;

public interface ISongService
{
    public SongOutDTO GetSong(int songID);
    public List<SongOutDTO> GetAllSongs();
    public bool DeleteSong(int songID);
    public int NewSong(SongInDTO SongOutDTO, ArtistInDTO ArtistInDTO, AlbumInDTO AlbumInDTO);
    
}