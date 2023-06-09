using PlaySoftBeta.DTOs;
using PlaySoftBeta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace PlaySoftBeta.Controllers;

[ApiController]
[Route("[controller]")]
public class SongController : ControllerBase
{
    private readonly ISongService _songService;
    public SongController(ISongService songService)
    {
        _songService = songService;
    }


    [HttpGet("{songID}"), Authorize]
    public async Task<ActionResult> GetSong(int songID)
    {
        var song = _songService.GetSong(songID);
        if (song != null)
        {
            return Ok(song);
        }
        return BadRequest("Song not found");
    }

    [HttpGet(), Authorize]
    public async Task<ActionResult> GetAll(int pageNumber)
    {
        var songs = _songService.GetAllSongs(pageNumber);
        if (songs != null)
        {
            return Ok(songs);
        }
        return BadRequest("Error getAll");
    }

    [HttpDelete("{songID}"), Authorize]
    public async Task<ActionResult> DeleteSong(int songID)
    {
        if (_songService.DeleteSong(songID))
        {
            return Accepted("Deleted");
        }
        return BadRequest("Error on song delete");
    }

    [HttpPost("create-with-artist-album"), Authorize]
    public async Task<ActionResult> AddSong(SongArtistAlbumDTO SongArtistAlbumDTO)
    {
        var songID = _songService.NewSong(SongArtistAlbumDTO.songInDTO, SongArtistAlbumDTO.artistInDTO, SongArtistAlbumDTO.albumInDTO);
        if (songID != -1)
        {
            return Ok(songID);
        }

        return BadRequest("Post error");
    }

    [HttpGet("count"), Authorize]
    public async Task<ActionResult> Count()
    {
        var songsNumber = _songService.CountSongs();
        if (songsNumber != -1)
        {
            return Ok(songsNumber);
        }
        return BadRequest("Count error;");
    }
}