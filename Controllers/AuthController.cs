using PlaySoftBeta.DTOs;
using PlaySoftBeta.Models;
using PlaySoftBeta.Services;
using Microsoft.AspNetCore.Mvc;

namespace PlaySoftBeta.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<User>> GetUser(AuthLoginInDTO user)
    {
        Console.WriteLine(user);
        var loggedUser = _authService.Login(user);
        if (loggedUser != null)
        {
            return Ok(loggedUser);
        }
        return BadRequest("this user doesn't exist");
    }

    [HttpPost("register")]
    public async Task<ActionResult> PostUser(AuhtRegisterUserDTO user)
    {
        if (_authService.Register(user))
        {
            return Ok("User registred");
        }
        return BadRequest("Bad register");
    }
}
