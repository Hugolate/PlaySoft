using PlaySoftBeta.DTOs;
using Microsoft.AspNetCore.Mvc;
using PlaySoftBeta.Services;
using Jwt;
using Microsoft.AspNetCore.Authorization;


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
    public async Task<ActionResult<String>> GetUser(AuthLoginInDTO user)
    {

        if (_authService.Login(user))
        {
            return JwtManager.GenerateToken(user.email);
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
