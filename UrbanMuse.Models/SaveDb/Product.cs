using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanMuse.Models;

public class Product //Заглавная Модель товара
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }//в идеале реализовать зависимость от размера, но без этого можно оставить
    public List<Photo> Photos { get; set; } = new List<Photo>();
    public DateTime CreatedAt { get; set; } //бесполезно, есть айди коллекции(пока нет)
}