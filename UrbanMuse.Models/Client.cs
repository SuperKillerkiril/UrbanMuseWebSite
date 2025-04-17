using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1;

public class Client
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
}