public class CourseService
{
    public async Task<List<Course>> GetCoursesAsync()
    {
        // Simulate fetching data from an API or database
        await Task.Delay(1000); // Simulate a delay

        return new List<Course>
        {
            new Course { ImageUrl = "image1.jpg", Description = "Course 1 description", Duration = "9 mins" },
            new Course { ImageUrl = "image2.jpg", Description = "Course 2 description", Duration = "9 mins" },
            new Course { ImageUrl = "image3.jpg", Description = "Course 3 description", Duration = "9 mins" }
        };
    }
}
