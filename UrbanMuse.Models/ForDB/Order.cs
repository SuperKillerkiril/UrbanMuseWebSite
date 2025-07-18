using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace UrbanMuse.Models;

public class Order
{
    [Key] public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShippedDate { get; set; }
    public string? Comment { get; set; }
    
    public string? Status { get; set; }
    
    public int? ClientId { get; set; }
    [ForeignKey("ClientId")] public Client? Client { get; set; }
    public int? ProductId { get; set; }
    [ForeignKey("ProductId")] public Product? Product { get; set; }
    
}