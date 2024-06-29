using ISP_MAUI.Entities;
using SQLite;

namespace ISP_MAUI.Services;

public class SQLiteService : IDbService
{
    private SQLiteAsyncConnection? _db;
    private string _dbPath;

    public SQLiteService(string dbPath)
    {
        _dbPath = dbPath;
    }

    public void Init()
    {
        _db = new SQLiteAsyncConnection(_dbPath);
        _db.CreateTableAsync<Cocktail>().Wait();
        _db.CreateTableAsync<Ingredient>().Wait();
        
        _db.InsertOrReplaceAsync(new Cocktail(1, "Margarita", 300, DateTime.Now));
        _db.InsertOrReplaceAsync(new Cocktail(2, "Long Island", 180, DateTime.Now));
        _db.InsertOrReplaceAsync(new Cocktail(3, "Bloody Mary", 260, DateTime.Now));

        _db.InsertOrReplaceAsync(new Ingredient(1, 1, "Tequila", (float)18.99, DateTime.Now));
        _db.InsertOrReplaceAsync(new Ingredient(2, 1, "Triple Sec", (float)28.99, DateTime.Now));
        _db.InsertOrReplaceAsync(new Ingredient(3, 1, "Lime", (float)1.99, DateTime.Now));
        _db.InsertOrReplaceAsync(new Ingredient(4, 1, "Salt", (float)0.99, DateTime.Now));
        
        _db.InsertOrReplaceAsync(new Ingredient(5, 2, "Vodka", (float)18.99, DateTime.Now));
        _db.InsertOrReplaceAsync(new Ingredient(6, 2, "White Rum", (float)28.99, DateTime.Now));
        _db.InsertOrReplaceAsync(new Ingredient(7, 2, "Silver Tequila", (float)19.99, DateTime.Now));
        _db.InsertOrReplaceAsync(new Ingredient(8, 2, "Gin", (float)15.99, DateTime.Now));
        _db.InsertOrReplaceAsync(new Ingredient(9, 2, "Triple Sec", (float)28.99, DateTime.Now));
        _db.InsertOrReplaceAsync(new Ingredient(10, 2, "Simple Syrup", (float)2.99, DateTime.Now));
        _db.InsertOrReplaceAsync(new Ingredient(11, 2, "Lemon Juice", (float)1.49, DateTime.Now));
        _db.InsertOrReplaceAsync(new Ingredient(12, 2, "Cola", (float)0.99, DateTime.Now));
        
        _db.InsertOrReplaceAsync(new Ingredient(13, 3, "Vodka", (float)18.99, DateTime.Now));
        _db.InsertOrReplaceAsync(new Ingredient(14, 3, "Tomato Juice", (float)1.49, DateTime.Now));
        _db.InsertOrReplaceAsync(new Ingredient(15, 3, "Lemon Juice", (float)1.49, DateTime.Now));
        _db.InsertOrReplaceAsync(new Ingredient(16, 3, "Worcestershire Sauce", (float)6.49, DateTime.Now));
        _db.InsertOrReplaceAsync(new Ingredient(17, 3, "Tabasco Sauce", (float)5.99, DateTime.Now));
        _db.InsertOrReplaceAsync(new Ingredient(18, 3, "Salt", (float)0.99, DateTime.Now));
        _db.InsertOrReplaceAsync(new Ingredient(19, 3, "Pepper", (float)0.99, DateTime.Now));
    }

    public async Task<IEnumerable<Cocktail>> GetAllCocktails()
    {
        return await _db.Table<Cocktail>().ToListAsync();
    }
    
    public async Task<IEnumerable<Ingredient>> GetCocktailIngredients(int id)
    {
        return await _db.Table<Ingredient>()
                        .Where(i => i.CocktailId == id)
                        .ToListAsync();
    }
}