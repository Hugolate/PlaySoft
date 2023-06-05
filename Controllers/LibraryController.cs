using PlaySoftBeta.DTOs;
using PlaySoftBeta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace PlaySoftBeta.Controllers;

[ApiController]
[Route("[controller]")]
public class LibraryController : ControllerBase
{
    private readonly IlibraryService _libraryService;
    public LibraryController(IlibraryService libraryService)
    {
        _libraryService = libraryService;
    }


    [HttpDelete("playlists/{playlistID}"), Authorize]
    public async Task<ActionResult> DeleteLine(int playlistID)
    {
        if (_libraryService.DeleteFromLibrary(playlistID))
        {
            return Ok("Deleted");
        }
        return BadRequest("Playlist not found");
    }

    [HttpPost("playlists"), Authorize]
    public async Task<ActionResult> AddSongToPlaylist(LibraryDTO libraryDTO)
    {
        _libraryService.AddPlaylistToLibrary(libraryDTO);
        return Ok();
    }

}