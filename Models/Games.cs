namespace GamesCRUD.Models;

public class Games
{
    public int id { get; set; }
    public int genreId { get; set; }
    public string name { get; set; }
    public decimal price { get; set; }
}