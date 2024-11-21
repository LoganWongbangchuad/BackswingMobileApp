namespace BackswingMobileApp.Services
{
    public class SessionService
    {
        // Current player instance for the session
        public Player? CurrentPlayer { get; set; }

        // Event to notify when the player changes (optional)
        public event Action? OnPlayerChanged;

        // Method to set the current player
        public void SetPlayer(Player player)
        {
            CurrentPlayer = player;
            OnPlayerChanged?.Invoke(); // Notify listeners of the update
        }

        // Method to update player details selectively
        public void UpdatePlayerDetails(Action<Player> updateAction)
        {
            if (CurrentPlayer == null)
                throw new InvalidOperationException("No player is currently logged in.");

            // Apply updates
            updateAction(CurrentPlayer);
            OnPlayerChanged?.Invoke(); // Notify listeners of the update
        }

        // Method to update the current player with new details
        public void UpdateUser(Player updatedPlayer)
        {
            if (CurrentPlayer == null)
                throw new InvalidOperationException("No player is currently logged in.");

            CurrentPlayer.Username = updatedPlayer.Username;
            CurrentPlayer.Email = updatedPlayer.Email;
            CurrentPlayer.Phone = updatedPlayer.Phone;
            CurrentPlayer.Address = updatedPlayer.Address;
            CurrentPlayer.Password = updatedPlayer.Password;
            // Add other properties as needed

            OnPlayerChanged?.Invoke(); // Notify listeners of the update
        }

        // Method to clear the current player (e.g., on logout)
        public void ClearPlayer()
        {
            CurrentPlayer = null;
            OnPlayerChanged?.Invoke(); // Notify listeners of the update
        }
    }
}
