using System.Net.Mime;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UrbanMuse.DataBase;
using UrbanMuse.Models;
using UrbanMuse.Services;
using UrbanMuseWeb.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazoredLocalStorage(); //Локал Сторадж
builder.Services.AddDbContext<ModelContext>(); //Контекст бд

builder.Services.AddHttpContextAccessor(); //Хттп контекст 
builder.Services.AddScoped<AuthService>(); //сервис авторизации

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme) //сервис аутентиф
    .AddCookie(options =>
    {
        options.LoginPath = "/auth";
        options.AccessDeniedPath = "/access-denied";
    });
builder.Services.AddAuthorization(); //сервис авториз

builder.Services.AddControllers(); //контроллеры

var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"]; //апи

builder.Services
    .AddScoped(sp => new HttpClient 
    { 
        BaseAddress = new Uri(apiBaseUrl) 
    });//апи

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();


var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ModelContext>();
context.Database.Migrate();

app.Run();