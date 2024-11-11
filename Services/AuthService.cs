using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackswingMobileApp.Services
{
    public class AuthService
    {
        private readonly List<Player> _players = new List<Player>(); // This could eventually be a database

        public async Task<bool> Register(Player newPlayer)
        {
            if (_players.Any(p => p.Username == newPlayer.Username || p.Email == newPlayer.Email))
                return false; // Username or Email already taken

            _players.Add(newPlayer); // Add player to the in-memory list
            return true;
        }

        public async Task<Player?> Login(string username, string password)
        {
            return _players.FirstOrDefault(p => p.Username == username && p.Password == password);
        }

        public async Task<bool> IsUsernameOrEmailTaken(string username, string email)
        {
            return _players.Any(p => p.Username == username || p.Email == email);
        }
    }
}
