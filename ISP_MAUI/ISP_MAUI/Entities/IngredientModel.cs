using System.ComponentModel.DataAnnotations.Schema;
using SQLite;

namespace ISP_MAUI.Entities;


[System.ComponentModel.DataAnnotations.Schema.Table("Ingredient")]
public class Ingredient
{
    [PrimaryKey, AutoIncrement, Indexed]
    public int Id { get; set; }
    [ForeignKey("Cocktail")]
    public int CocktailId { get; set; }
    
    public string? Name { get; set; }
    public float Price { get; set; }
    public DateTime AddedAt { get; set; }
    
    public Ingredient() {}
    
    public Ingredient(int id, int cocktailId, string name, float price, DateTime addedAt)
    {
        Id = id;
        CocktailId = cocktailId;
        Name = name;
        Price = price;
        AddedAt = addedAt;
    }
}