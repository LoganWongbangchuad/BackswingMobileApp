public class LeaderboardService
{
    public async Task<List<Player>> GetLeaderboardAsync()
    {
        // Simulate fetching data from an API or database
        await Task.Delay(1000); // Simulate a delay

        return new List<Player>
        {
            new Player { Name = "Logan Wongbangchuad", Score = 84 },
            // Add more players as needed
        };
    }
}
