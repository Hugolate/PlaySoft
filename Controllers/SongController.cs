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
        else
        {
            return BadRequest("Not found");
        }

    }

    [HttpPost("create-with-artist-album"), Authorize]
    public async Task<ActionResult> AddSong(SongArtistAlbumDTO SongArtistAlbumDTO)
    {
        var songID = _songService.NewSong(SongArtistAlbumDTO.songInDTO, SongArtistAlbumDTO.artistInDTO, SongArtistAlbumDTO.albumInDTO);
        if (songID != null)
        {
            return Ok(songID);
        }

        return BadRequest("Not found");


    }
}