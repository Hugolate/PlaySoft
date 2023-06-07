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
        if (artists != null)
        {
            return Ok(artists);
        }
        return BadRequest("Error getAll");
    }

    [HttpDelete("{artistID}"), Authorize]
    public async Task<ActionResult> DeleteArtist(int artistID)
    {
        if (_artistService.DeleteArtist(artistID))
        {
            return Accepted("Deleted");
        }
        return BadRequest("Error on artist delete");
    }

    [HttpGet("count"), Authorize]
    public async Task<ActionResult> Count()
    {
        var artistsNumber = _artistService.CountArtists();
        if (artistsNumber == -1)
        {
            return BadRequest("Error count");
        }
        return Ok(artistsNumber);

    }
}
