using Microsoft.AspNetCore.Authorization;
using PlaySoftBeta.DTOs;
using PlaySoftBeta.Services;
using Microsoft.AspNetCore.Mvc;

namespace PlaySoftBeta.Controllers;

[ApiController]
[Route("[controller]")]
public class PlaylistController : ControllerBase
{
    private readonly IPLaylistService _pLaylistService;

    public PlaylistController(IPLaylistService pLaylistService)
    {
        _pLaylistService = pLaylistService;
    }

    [HttpPost(), Authorize]
    public async Task<ActionResult> CreatePlaylist(PlaylistDTO pLaylist)
    {
        if (_pLaylistService.CreatePlaylist(pLaylist))
        {
            return Ok("Playlist created");
        }
        return BadRequest("Create playlist error");
    }

    [HttpDelete("{playlistID}"), Authorize]
    public async Task<ActionResult> DeletePlaylist(int pLaylistID)
    {
        if (_pLaylistService.DeletePlaylist(pLaylistID))
        {
            return Ok("Deleted");
        }
        return BadRequest("Playlist not found");
    }

    [HttpPut(), Authorize]
    public async Task<ActionResult> EditPLaylist(EditPLaylistDTO editPLaylistDTO)
    {
        if (_pLaylistService.EditPLaylist(editPLaylistDTO))
        {
            return Ok("Playlist Updated");
        }
        return BadRequest("Error updating playlist");
    }

    [HttpGet("{playlistID}"), Authorize]
    public async Task<ActionResult> GetSongsId(int playlistID, string? orderKey, string? order)
    {
        var songsID = _pLaylistService.GetSongsId(playlistID, orderKey, order);

        if (songsID != null && songsID.Any())
        {
            return Ok(songsID);
        }
        else
        {
            return BadRequest("You don't have songs yet");
        }
    }


    [HttpPost("{playlistID}/songs"), Authorize]
    public async Task<ActionResult> AddSongToPlaylist(int playlistID, [FromBody] PlaylistLinesDTO playlistLinesDTO)
    {
        playlistLinesDTO.playlistID = playlistID;
        _pLaylistService.AddSongToPlaylist(playlistLinesDTO);
        return Ok();
    }
}
