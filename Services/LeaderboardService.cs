using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class LeaderboardService
{
    private readonly SQLiteAsyncConnection _database;

    public LeaderboardService()
    {
        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "players.db");
        _database = new SQLiteAsyncConnection(databasePath);
        _database.CreateTableAsync<Player>(CreateFlags.None).Wait();
    }

    // Create
    public Task<int> SavePlayerAsync(Player player)
    {
        return  _database.InsertAsync(player);

    }

    // Read all players
    public Task<List<Player>> GetPlayersAsync()
    {
        return _database.Table<Player>().ToListAsync();
    }

    // Read a single player by ID
    public Task<Player> GetPlayerAsync(int id)
    {
        return _database.FindAsync<Player>(id);
    }

    // Update
    public Task<int> UpdatePlayerAsync(Player player)
    {
        return  _database.UpdateAsync(player);
    }

    // Delete
    public Task<int> DeletePlayerAsync(int id)
    {
        return _database.DeleteAsync<Player>(id);
    }

    //// Insert or Update
    //public async Task<int> SaveOrUpdatePlayerAsync(Player player)
    //{
    //    if (player.Id != 0)
    //    {
    //        var existingPlayer = await GetPlayerAsync(player.Id);
    //        if (existingPlayer != null)
    //        {
    //            return await UpdatePlayerAsync(player);
    //        }
    //    }
    //    return await SavePlayerAsync(player);
    //}

}