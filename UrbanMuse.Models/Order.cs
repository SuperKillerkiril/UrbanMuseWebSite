using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace UrbanMuse.Models;

public class Order
{
    [Key] public int Id { get; set; }
}