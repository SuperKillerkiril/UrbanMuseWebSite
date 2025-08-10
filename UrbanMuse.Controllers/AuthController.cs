using Microsoft.AspNetCore.Mvc;
using UrbanMuse.Models;
using UrbanMuse.Services;

namespace UrbanMuse.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var success = await _authService.LoginAsync(model.Email, model.Password);
        if (!success)
            return Unauthorized();

        return Ok();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _authService.LogoutAsync();
        return Ok();
    }
}