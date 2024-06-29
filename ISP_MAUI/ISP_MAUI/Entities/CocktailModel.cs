using SQLite;

namespace ISP_MAUI.Entities;

[System.ComponentModel.DataAnnotations.Schema.Table("Cocktail")]
public class Cocktail
{
    [PrimaryKey, AutoIncrement, Indexed]
    public int Id { get; set; }
    
    public string? Name { get; set; }
    public int Volume { get; set; }
    public DateTime AddedAt { get; set; }

    public Cocktail() {}
    public Cocktail(int id, string name, int volume, DateTime addedAt)
    {
        Id = id;
        Name = name;
        Volume = volume;
        AddedAt = addedAt;
    }
}