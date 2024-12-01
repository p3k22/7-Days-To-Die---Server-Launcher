namespace _7D2D_ServerLauncher.Models;

using System.Collections.ObjectModel;

public static class ComboBoxOptions
{
   public static ObservableCollection<string> DeathPenalty { get; } =
         ["Nothing", "XP Only", "Injured", "Permanent Death"];

   public static ObservableCollection<string> DisabledNetworkProtocols { get; } =
         ["None", "SteamNetworking", "LiteNetLib", "Both"];

   public static ObservableCollection<string> DropOnDeath { get; } =
      [
         "Nothing",
         "Everything",
         "Toolbelt Only",
         "Backpack Only",
         "Delete All"
      ];

   public static ObservableCollection<string> DropOnQuit { get; } =
         ["Nothing", "Everything", "Toolbelt Only", "Backpack Only"];

   public static ObservableCollection<string> FeralSenseTimeOfDay { get; } = ["Off", "Day", "Night", "All"];

   public static ObservableCollection<string> FriendlyFire { get; } =
         ["No Killing", "Kill Allies Only", "Kill Strangers Only", "Kill Everyone"];

   public static ObservableCollection<string> GameDifficulty { get; } =
         ["Scavenger", "Adventurer", "Nomad", "Warrior", "Survivalist", "Insane In The Membrane"];

   public static ObservableCollection<string> HideCommands { get; } =
         ["None", "Telnet/ControlPanel", "Telnet/ControlPanel/Remote", "Everything"];

   public static ObservableCollection<string> LandClaimDecay { get; } = ["Slow", "Fast", "None"];

   public static ObservableCollection<string> Languages { get; } =
      [
         "English", "Brazilian", "French", "German", "Italian", "Japanese", "Korean", "Polish", "Portuguese", "Russian",
         "Simplified Chinese", "Traditional Chinese", "Turkish"
      ];

   public static ObservableCollection<string> MapSizes { get; } =
      [
         "2048", "4096", "6144", "8192", "10240"
      ];

   public static ObservableCollection<string> MapTypes { get; } =
      [
         "RWG", "Navezgane", "Pregen04k1", "Pregen04k2", "Pregen04k3", "Pregen04k4", "Pregen06k1", "Pregen06k2",
         "Pregen06k3", "Pregen06k4", "Pregen08k1", "Pregen08k2", "Pregen08k3", "Pregen08k4", "Pregen10k1", "Pregen10k2",
         "Pregen10k3", "Pregen10k4"
      ];

   public static ObservableCollection<string> Regions { get; } =
      [
         "Europe", "North America East", "North America West", "Central America", "South America", "Russia", "Asia",
         "Middle East", "Africa", "Oceania"
      ];

   public static ObservableCollection<string> ServerVisibility { get; } = ["Not Listed", "Friends Only", "Public"];

   public static ObservableCollection<string> TrueFalse { get; } = ["True", "False"];

   public static ObservableCollection<string> ZombieDifficulty { get; } = ["Normal", "Feral"];

   public static ObservableCollection<string> ZombieMoveSpeed { get; } = ["Walk", "Jog", "Run", "Sprint", "Nightmare"];
}