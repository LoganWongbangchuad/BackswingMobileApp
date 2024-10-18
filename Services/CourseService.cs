using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class CourseService
{
    private readonly SQLiteAsyncConnection _database;

    public CourseService()
    {
        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "courses.db");
        _database = new SQLiteAsyncConnection(databasePath);
        _database.CreateTableAsync<Course>(CreateFlags.None).Wait();
    }

    // Create
    public Task<int> SaveCourseAsync(Course course)
    {
        return _database.InsertAsync(course);
    }

    // Read
    public Task<List<Course>> GetCoursesAsync()
    {
        return _database.Table<Course>().ToListAsync();
    }

    public Task<Course> GetCourseAsync(int id)
    {
        return _database.FindAsync<Course>(id);
    }

    // Update
    public Task<int> UpdateCourseAsync(Course course)
    {
        return _database.UpdateAsync(course);
    }

    // Delete
    public Task<int> DeleteCourseAsync(int id)
    {
        return _database.DeleteAsync<Course>(id);
    }
}
