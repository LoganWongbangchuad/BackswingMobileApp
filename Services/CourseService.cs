using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using YourNamespace;

public class CourseService
{
    private readonly SQLiteAsyncConnection _database;

    // Constructor that uses DatabaseHelper to initialize the connection
    public CourseService()
    {
        //DatabaseHelper.InitializeDatabaseAsync().Wait(); // Ensure the database is initialized
        //_database = DatabaseHelper.GetDatabaseConnection();

        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "courses.db");
        _database = new SQLiteAsyncConnection(databasePath);
        _database.CreateTableAsync<Course>(CreateFlags.None).Wait();
    }

    // Create a new course
    public async Task<int> SaveCourseAsync(Course course)
    {
        try
        {
            return await _database.InsertAsync(course);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving course: {ex.Message}");
            return -1; // Indicate failure
        }
    }

    // Read all courses
    public async Task<List<Course>> GetCoursesAsync()
    {
        try
        {
            return await _database.Table<Course>().ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting courses: {ex.Message}");
            return new List<Course>();
        }
    }

    // Read a specific course by ID
    public async Task<Course> GetCourseAsync(int id)
    {
        try
        {
            return await _database.FindAsync<Course>(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting course: {ex.Message}");
            return null;
        }
    }

    // Update an existing course
    public async Task<int> UpdateCourseAsync(Course course)
    {
        try
        {
            return await _database.UpdateAsync(course);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating course: {ex.Message}");
            return -1; // Indicate failure
        }
    }

    // Delete a course by ID
    public async Task<int> DeleteCourseAsync(int id)
    {
        try
        {
            var course = await _database.FindAsync<Course>(id);
            if (course != null)
            {
                return await _database.DeleteAsync(course);
            }
            return 0; // Indicate no record was found to delete
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting course: {ex.Message}");
            return -1; // Indicate failure
        }
    }
}
