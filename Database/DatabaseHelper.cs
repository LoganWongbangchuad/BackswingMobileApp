//using SQLite;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace BackswingMobileApp
//{
//    public class DatabaseHelper
//    {
//        private const string DB_NAME = "BackswingMobileApp.db";
//        private readonly SQLiteAsyncConnection _connection;

//        public DatabaseHelper()
//        {
//            _connection = SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
//            _connection.CreateTableAsync<Player>();
//        }

//        public async Task<List<Player>> GetPlayer()
//        {
//            return await _connection.Table<Player>().ToListAsync();
//        }

//        public async Task<Player> GetPlayer(int id)
//        {
//            return await _connection.Table<Player>().Where(x => x.Id == id).FirstOrDefaultAsync();
//        }

//        public async Task Create(Player player)
//        {
//            await _connection.InsertAsync(player);
//        }

//        public async Task Update(Player player)
//        {
//            await _connection.UpdateAsync(player);
//        }

//        public async Task Delete(Player player)
//        {
//            await _connection.DeleteAsync(player);
//        }
//        //    private static SQLiteAsyncConnection _database;

//        //    // Method to initialize the database connection
//        //    public static async Task InitializeDatabaseAsync()
//        //    {
//        //        if (_database != null)
//        //        {
//        //            return;
//        //        }

//        //        string dbFileName = "BackswingDatabase.db";
//        //        string dbPath = Path.Combine(FileSystem.AppDataDirectory, dbFileName);

//        //        // Copy the database file from the app's resources to the app's directory if it doesn't already exist
//        //        if (!File.Exists(dbPath))
//        //        {
//        //            try
//        //            {
//        //                using (var stream = await FileSystem.OpenAppPackageFileAsync(dbFileName))
//        //                {
//        //                    using (var newStream = File.Create(dbPath))
//        //                    {
//        //                        await stream.CopyToAsync(newStream);
//        //                    }
//        //                }
//        //            }
//        //            catch (Exception ex)
//        //            {
//        //                // Handle exceptions (e.g., file not found, access denied)
//        //                Console.WriteLine($"Error copying database file: {ex.Message}");
//        //                throw;
//        //            }
//        //        }

//        //        // Create the SQLite connection to the copied database
//        //        _database = new SQLiteAsyncConnection(dbPath);

//        //        // Optional: Create tables if necessary
//        //        // await _database.CreateTableAsync<Course>();
//        //    }

//        //    // New method to get the database connection
//        //    public static SQLiteAsyncConnection GetDatabaseConnection()
//        //    {
//        //        if (_database == null)
//        //        {
//        //            throw new InvalidOperationException("Database not initialized. Call InitializeDatabaseAsync() first.");
//        //        }
//        //        return _database;
//        //    }
//        //}

//        //// Example model for Courses
//        //public class Course
//        //{
//        //    [PrimaryKey, AutoIncrement]
//        //    public int Id { get; set; }
//        //    public string CourseName { get; set; }
//        //    public string ImageUrl { get; set; }
//        //    public string Description { get; set; }
//        //    public int Holes { get; set; }
//        //}
//    }
//}