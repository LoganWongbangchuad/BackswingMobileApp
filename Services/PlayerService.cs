using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;

public class PlayerService
{
    private readonly SQLiteAsyncConnection _database;

    public PlayerService()
    {
        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "players.db");
        _database = new SQLiteAsyncConnection(databasePath);
        _database.CreateTableAsync<Player>().Wait();
    }

    public async Task<int> SavePlayerAsync(Player player)
    {
        try
        {
            return await _database.InsertAsync(player);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving player: {ex.Message}");
            return -1; // Indicate failure
        }
    }
}