using System.Collections.Generic;

namespace MyKillDeathMod
{
    /// <summary>
    /// Tracks kill and death statistics for players.
    /// </summary>
    public class KillDeathTracker
    {
        // Internal dictionary to store player stats keyed by player name.
        private Dictionary<string, PlayerStats> _stats = new Dictionary<string, PlayerStats>();

        /// <summary>
        /// Called when a player gets a kill.
        /// </summary>
        /// <param name="player">The player who made the kill.</param>
        public void OnPlayerKill(Player player)
        {
            if (player == null)
                return;

            // Ensure the player is added to the dictionary.
            if (!_stats.ContainsKey(player.Name))
            {
                _stats[player.Name] = new PlayerStats();
            }

            // Increment kill count.
            _stats[player.Name].Kills++;
        }

        /// <summary>
        /// Called when a player dies.
        /// </summary>
        /// <param name="player">The player who died.</param>
        public void OnPlayerDeath(Player player)
        {
            if (player == null)
                return;

            // Ensure the player is added to the dictionary.
            if (!_stats.ContainsKey(player.Name))
            {
                _stats[player.Name] = new PlayerStats();
            }

            // Increment death count.
            _stats[player.Name].Deaths++;
        }

        /// <summary>
        /// Resets all players' kill/death statistics.
        /// </summary>
        public void ResetStats()
        {
            _stats.Clear();
        }

        /// <summary>
        /// Gets a read-only dictionary of all player statistics.
        /// </summary>
        public IReadOnlyDictionary<string, PlayerStats> Stats => _stats;

        /// <summary>
        /// Represents the kill/death statistics for a player.
        /// </summary>
        public class PlayerStats
        {
            public int Kills { get; set; }
            public int Deaths { get; set; }

            public PlayerStats()
            {
                Kills = 0;
                Deaths = 0;
            }
        }
    }
}

// -----------------------------------------------------------------
// IMPORTANT: The following is a placeholder for the Player class.
// In your actual mod, the Player class should come from the game's API.
// -----------------------------------------------------------------
public class Player
{
    public string Name { get; set; }

    public Player(string name)
    {
        Name = name;
    }
}

