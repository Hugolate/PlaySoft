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
        if (albums != null)
        {
            return Ok(albums);

        }
        return BadRequest("Error getAll");
    }

    [HttpDelete("{albumID}"), Authorize]
    public async Task<ActionResult> DeleteAlbum(int albumID)
    {
        if (_albumService.DeleteAlbum(albumID))
        {
            return Accepted("Deleted");
        }
        return BadRequest("Error on album delete");
    }

    [HttpGet("count"), Authorize]
    public async Task<ActionResult> Count()
    {
        var albumNumber = _albumService.CountAlbums();

        if (albumNumber == -1)
        {
            return BadRequest("Count error");
        }

        return Ok(albumNumber);

    }
}
