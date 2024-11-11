using SQLite;
using System;
using System.Threading.Tasks;
//using YourNamespace;

public class PlayerService
{
    private readonly SQLiteAsyncConnection _database;

    // Constructor that uses DatabaseHelper to initialize the connection
    public PlayerService()
    {
        //DatabaseHelper.InitializeDatabaseAsync().Wait(); // Ensure the database is initialized
        //_database = DatabaseHelper.GetDatabaseConnection();

        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "players.db");
        _database = new SQLiteAsyncConnection(databasePath);
        _database.CreateTableAsync<Player>().Wait();

    }

    // Method to save a player asynchronously
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

    // Optional: Method to get all players
    public async Task<List<Player>> GetPlayersAsync()
    {
        try
        {
            return await _database.Table<Player>().ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting players: {ex.Message}");
            return new List<Player>();
        }
    }

    // Optional: Method to update an existing player
    public async Task<int> UpdatePlayerAsync(Player player)
    {
        try
        {
            return await _database.UpdateAsync(player);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating player: {ex.Message}");
            return -1; // Indicate failure
        }
    }

    // Optional: Method to delete a player by ID
    public async Task<int> DeletePlayerAsync(int playerId)
    {
        try
        {
            var player = await _database.FindAsync<Player>(playerId);
            if (player != null)
            {
                return await _database.DeleteAsync(player);
            }
            return 0; // Indicate no record was found to delete
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting player: {ex.Message}");
            return -1; // Indicate failure
        }
    }
}