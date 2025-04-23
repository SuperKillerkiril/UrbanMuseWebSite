using System.ComponentModel.DataAnnotations;

namespace UrbanMuse.Models;

public class Client
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }
    public RoleEnum Role { get; set; }
}