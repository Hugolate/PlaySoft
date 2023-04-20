using PlaySoftBeta.DTOs;
using PlaySoftBeta.Models;
using PlaySoftBeta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace PlaySoftBeta.Controllers;

[Route("[controller]")]
[ApiController]
public class SearchController : ControllerBase
{

    private readonly ISearchService _searchService;

    public SearchController( ISearchService serarchService)
    {
        _searchService = serarchService;
    }



    [HttpGet("{name}"), Authorize]
    public async Task<ActionResult> SearchSongsAndUsers(string query)
    {
        var songsAndUsers = _searchService.SearchByName(query);
        if (songsAndUsers != null)
        {
            return Ok(songsAndUsers);
        }
        else
        {
            return BadRequest("Not found");
        }
    }

}
