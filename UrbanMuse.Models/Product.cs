using System.ComponentModel.DataAnnotations;

namespace UrbanMuse.Models;

public class Product
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public string Image { get; set; } = "LocalImage/notFound.png";
    public DateTime CreatedAt { get; set; }
    public int Size { get; set; }
    
}