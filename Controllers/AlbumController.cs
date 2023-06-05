using PlaySoftBeta.DTOs;
using Microsoft.AspNetCore.Mvc;
using PlaySoftBeta.Services;
using Jwt;
using Microsoft.AspNetCore.Authorization;


namespace PlaySoftBeta.Controllers;

[Route("[controller]")]
[ApiController]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    [HttpGet(), Authorize]
    public async Task<ActionResult> GetAll(int pageNumber)
    {
        var albums = _albumService.GetAllAlbums(pageNumber);

        return Ok(albums);

    }

    [HttpDelete("{albumID}"), Authorize]
    public async Task<ActionResult> DeleteAlbum(int albumID)
    {
        if (_albumService.DeleteAlbum(albumID))
        {
            return Ok("Deleted");
        }
        return BadRequest("Playlist not found");
    }

    [HttpGet("count"), Authorize]
    public async Task<ActionResult> Count()
    {
        var albumNumber = _albumService.CountAlbums();

        return Ok(albumNumber);

    }
}
