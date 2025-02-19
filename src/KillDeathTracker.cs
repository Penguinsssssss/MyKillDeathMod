using System.Collections.Generic;
using UnityEngine;

namespace MyKillDeathMod
{
    /// <summary>
    /// Tracks kill and death statistics for players.
    /// </summary>
    public class KillDeathTracker : MonoBehaviour
    {
        // Dictionary to store player stats, keyed by playerID (unique per player)
        private Dictionary<int, PlayerStats> _stats = new Dictionary<int, PlayerStats>();

        /// <summary>
        /// Called when a player gets a kill.
        /// </summary>
        /// <param name="killer">The player who made the kill.</param>
        public void OnPlayerKill(Player killer)
        {
            if (killer == null) return;

            int playerID = killer.playerID;

            // Ensure the player is added to the dictionary.
            if (!_stats.ContainsKey(playerID))
            {
                _stats[playerID] = new PlayerStats();
            }

            // Increment kill count.
            _stats[playerID].Kills++;
        }

        /// <summary>
        /// Called when a player dies.
        /// </summary>
        /// <param name="victim">The player who died.</param>
        public void OnPlayerDeath(Player victim)
        {
            if (victim == null) return;

            int playerID = victim.playerID;

            // Ensure the player is added to the dictionary.
            if (!_stats.ContainsKey(playerID))
            {
                _stats[playerID] = new PlayerStats();
            }

            // Increment death count.
            _stats[playerID].Deaths++;
        }

        /// <summary>
        /// Resets all players' kill/death statistics at the start of a new game.
        /// </summary>
        public void ResetStats()
        {
            _stats.Clear();
        }

        /// <summary>
        /// Gets a read-only dictionary of all player statistics.
        /// </summary>
        public IReadOnlyDictionary<int, PlayerStats> Stats => _stats;

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

