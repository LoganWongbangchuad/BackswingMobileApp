//using BackswingMobileApp.Models;
using SQLite;

public class Course
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string CourseName { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int Holes { get; set; }

    //public List<Leaderboard> Leaderboards { get; set; } // Navigation property for related scores
}