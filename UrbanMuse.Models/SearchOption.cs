namespace UrbanMuse.Models;

public class SearchOption
{
    public string SearchText { get; set; }
    public int Min { get; set; }
    public int Max { get; set; } = int.MaxValue;
    public ProductType ProductType { get; set; }
}