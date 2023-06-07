using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
using PlaySoftBeta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace PlaySoftBeta.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpDelete("{userID}"), Authorize]
    public async Task<ActionResult> DeleteUser(int userID)
    {
        if (_userService.DeleteUser(userID))
        {
            return Accepted("Deleted");
        }
        return BadRequest("Error on user delete");
    }

    [HttpGet("{ukid}"), Authorize]
    public ActionResult<User> Get(int ukid)
    {
        var user = _userService.GetUser(ukid);
        if (user != null)
        {
            return Ok(user);
        }
        return BadRequest("User not found");
    }
}
