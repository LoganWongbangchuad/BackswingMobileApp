//using SQLite;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading.Tasks;

//public class DatabaseService
//{
//    private readonly SQLiteAsyncConnection _database;

//    public DatabaseService()
//    {
//        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db");
//        _database = new SQLiteAsyncConnection(databasePath);
//        _database.CreateTableAsync<Player>().Wait();
//    }

//    // Create
//    public Task<int> SaveItemAsync(Player item)
//    {
//        return _database.InsertAsync(item);
//    }

//    // Read
//    public Task<List<Player>> GetItemsAsync()
//    {
//        return _database.Table<Player>().ToListAsync();
//    }

//    public Task<Player> GetItemAsync(int id)
//    {
//        return _database.FindAsync<Player>(id);
//    }

//    // Update
//    public Task<int> UpdateItemAsync(Player item)
//    {
//        return _database.UpdateAsync(item);
//    }

//    // Delete
//    public Task<int> DeleteItemAsync(int id)
//    {
//        return _database.DeleteAsync<Player>(id);
//    }
//}
