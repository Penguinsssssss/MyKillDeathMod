using BepInEx;
using BepInEx.Logging;
using UnityEngine;

// Namespace for the mod (can be adjusted as needed)
namespace MyKillDeathMod
{
    // BepInEx attribute to register the mod.
    [BepInPlugin("com.yourusername.mykilldeathmod", "MyKillDeathMod", "1.0.0")]
    public class MyKillDeathMod : BaseUnityPlugin
    {
        // Public logger for logging mod-related messages.
        internal static ManualLogSource LogInstance;

        // Instances of our kill/death tracking and GUI classes.
        private KillDeathTracker _tracker;
        private KillDeathGUI _gui;

        // Called when the mod is loaded.
        private void Awake()
        {
            LogInstance = Logger;
            LogInstance.LogInfo("MyKillDeathMod loaded!");

            // Initialize the tracker and GUI components.
            _tracker = new KillDeathTracker();
            _gui = new KillDeathGUI();

            // Subscribe to game events.
            // (Assuming these events are provided by Rounds or RoundsWithFriends)
            GameEvents.OnGameStart += OnGameStart;
            GameEvents.OnPlayerKill += _tracker.OnPlayerKill;
            GameEvents.OnPlayerDeath += _tracker.OnPlayerDeath;
        }

        // This method is called at the start of a new game.
        private void OnGameStart()
        {
            // Reset the kill/death statistics at the start of each game.
            _tracker.ResetStats();
        }

        // Called when the mod is unloaded/destroyed.
        private void OnDestroy()
        {
            // Unsubscribe from events to prevent memory leaks.
            GameEvents.OnGameStart -= OnGameStart;
            GameEvents.OnPlayerKill -= _tracker.OnPlayerKill;
            GameEvents.OnPlayerDeath -= _tracker.OnPlayerDeath;
        }

        // OnGUI is called for rendering and handling GUI events.
        private void OnGUI()
        {
            // Render the kill/death GUI in the game lobby.
            _gui.Render(_tracker);
        }
    }
}
