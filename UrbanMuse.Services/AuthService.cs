using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using UrbanMuse.DataBase;
using UrbanMuse.Models;

namespace UrbanMuse.Services;

public class AuthService
{
    private readonly ModelContext _context;
    private readonly IHttpContextAccessor _contextAccessor;

    public AuthService(ModelContext context, IHttpContextAccessor contextAccessor)
    {
        _context = context;
        _contextAccessor = contextAccessor;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var user = await _context.Clients.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        if (user == null)
            return false;
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };
        var identity = new ClaimsIdentity(claims, "CookieAuthenticationDefaults.AuthenticationScheme");
        var principal = new ClaimsPrincipal(identity);

        await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        return true;
    }

    public async Task LogoutAsync()
    {
        await _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public async Task<bool> RegisterAsync(User newUser)
    {
        var exists = await _context.Clients.AnyAsync(u => u.Email == newUser.Email);
        if (exists) return false;
        
        _context.Clients.Add(newUser);
        await _context.SaveChangesAsync();
        return true;
    }
}