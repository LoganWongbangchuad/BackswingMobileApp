public class CourseService
{
    public async Task<List<Course>> GetCoursesAsync()
    {
        // Simulate fetching data from an API or database
        await Task.Delay(1000); // Simulate a delay

        return new List<Course>
        {
            new Course { CourseName = "Quicksand Golf Course", ImageUrl = "image1.jpg", Description = "Course 1 description", Holes = 9 },
            new Course { CourseName = "Riverside Golf Course", ImageUrl = "image2.jpg", Description = "Course 2 description", Holes = 18 },
            new Course { CourseName = "Bentwood Golf Course", ImageUrl = "image3.jpg", Description = "Course 3 description", Holes = 18 }
        };
    }
}
