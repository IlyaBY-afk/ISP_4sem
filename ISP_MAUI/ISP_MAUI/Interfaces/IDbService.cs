using ISP_MAUI.Entities;

namespace ISP_MAUI.Services;

public interface IDbService
{
    Task<IEnumerable<Cocktail>> GetAllCocktails();
    Task<IEnumerable<Ingredient>> GetCocktailIngredients(int id);
    void Init();
}