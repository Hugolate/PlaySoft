using PlaySoftBeta.DTOs;
using Microsoft.AspNetCore.Mvc;
using PlaySoftBeta.Services;
using Jwt;
using Microsoft.AspNetCore.Authorization;


namespace PlaySoftBeta.Controllers;

[Route("[controller]")]
[ApiController]
public class ArtistController : ControllerBase
{
    private readonly IArtistService _artistService;

    public ArtistController(IArtistService artistService)
    {
        _artistService = artistService;
    }

    [HttpGet(), Authorize]
    public async Task<ActionResult> GetAll(int pageNumber)
    {
        var artists = _artistService.GetAllArtists(pageNumber);

        return Ok(artists);

    }

    [HttpDelete("{artistID}"), Authorize]
    public async Task<ActionResult> DeleteArtist(int artistID)
    {
        if (_artistService.DeleteArtist(artistID))
        {
            return Ok("Deleted");
        }
        return BadRequest("Playlist not found");
    }

    [HttpGet("count"), Authorize]
    public async Task<ActionResult> Count()
    {
        var artistsNumber = _artistService.CountArtists();

        return Ok(artistsNumber);

    }
}
