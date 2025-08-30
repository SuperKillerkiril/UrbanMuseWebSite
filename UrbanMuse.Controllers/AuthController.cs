using Microsoft.AspNetCore.Mvc;
using UrbanMuse.Models;
using UrbanMuse.Services;

namespace UrbanMuse.Controllers;

[Route("api/auth")]
[ApiController]
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
    [HttpPost(Name = "register")]
    public async Task<IActionResult> Registred([FromBody] LoginModel model)
    {
        User user = new User
        {
            Email = model.Email,
            Password = model.Password
        };
        await _authService.RegisterAsync(user);
        return Ok();
    }


    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("тест");
    }
    
}