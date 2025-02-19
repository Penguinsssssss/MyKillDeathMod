using System.Collections.Generic;
using UnityEngine;

namespace MyKillDeathMod
{
    /// <summary>
    /// Handles displaying the kill/death statistics GUI in the game.
    /// </summary>
    public class KillDeathGUI : MonoBehaviour
    {
        private bool showGUI = false; // Initially hidden

        /// <summary>
        /// Checks for input to toggle the GUI.
        /// </summary>
        private void Update()
        {
            // Detect tilde (~) key press
            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                showGUI = !showGUI;
            }
        }

        /// <summary>
        /// Renders the kill/death scoreboard.
        /// </summary>
        private void OnGUI()
        {
            if (!showGUI) return;

            // Define GUI box position & size
            Rect windowRect = new Rect(50, 50, 300, 300);
            GUI.Box(windowRect, "Kill/Death Stats");

            // Start drawing inside the box
            GUILayout.BeginArea(new Rect(60, 80, 280, 200));

            // Display headers
            GUILayout.Label("Player      | Kills | Deaths");
            GUILayout.Label("----------------------------");

            // Get the tracker instance (assuming it exists in the scene)
            KillDeathTracker tracker = FindObjectOfType<KillDeathTracker>();
            if (tracker == null) return;

            // Display each player's stats
            foreach (KeyValuePair<string, KillDeathTracker.PlayerStats> entry in tracker.Stats)
            {
                GUILayout.Label($"{entry.Key.PadRight(10)} | {entry.Value.Kills}    | {entry.Value.Deaths}");
            }

            GUILayout.EndArea();
        }
    }
}
