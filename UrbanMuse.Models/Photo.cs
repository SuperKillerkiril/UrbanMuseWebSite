using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanMuse.Models;

public class Photo
{
    [Key] public int id { get; set; }
    public byte[] Data { get; set; }
    public string ContentType { get; set; }
    
    public int ProductId { get; set; }
    [ForeignKey("ProductId")] Product Product { get; set; }
}