using System.Collections.Generic;
using UnityEngine;

namespace MyKillDeathMod
{
    /// <summary>
    /// Handles displaying the kill/death statistics GUI in the game.
    /// </summary>
    public class KillDeathGUI
    {
        private bool showGUI = true; // Toggle GUI visibility

        /// <summary>
        /// Renders the kill/death scoreboard.
        /// </summary>
        /// <param name="tracker">The KillDeathTracker containing player stats.</param>
        public void Render(KillDeathTracker tracker)
        {
            if (!showGUI || tracker == null) return;

            // Define GUI box position & size
            Rect windowRect = new Rect(50, 50, 300, 300);
            GUI.Box(windowRect, "Kill/Death Stats");

            // Start drawing inside the box
            GUILayout.BeginArea(new Rect(60, 80, 280, 200));

            // Display headers
            GUILayout.Label("Player      | Kills | Deaths");
            GUILayout.Label("----------------------------");

            // Display each player's stats
            foreach (KeyValuePair<string, KillDeathTracker.PlayerStats> entry in tracker.Stats)
            {
                GUILayout.Label($"{entry.Key.PadRight(10)} | {entry.Value.Kills}    | {entry.Value.Deaths}");
            }

            GUILayout.EndArea();

            // Toggle button
            if (GUI.Button(new Rect(50, 360, 100, 30), "Toggle Stats"))
            {
                showGUI = !showGUI;
            }
        }
    }
}
