namespace _7D2D_ServerLauncher.Helpers;

using _7D2D_ServerLauncher.Models;

using System.Diagnostics;
using System.IO;
using System.Windows;

public static class ServerLauncherHelper
{
   /// <summary>
   ///    Returns a Tuple containing the directory and file name of the 7d2d.exe
   /// </summary>
   private static (string directory, string gameName) GameFullPath
   {
      get
      {
         var gameDirectory = GetGameDirectory();

         var gameName = File.Exists(Path.Combine(gameDirectory, "7DaysToDie.exe")) ?
                           "7DaysToDie.exe" :
                           "7DaysToDieServer.exe";

         if (!File.Exists(Path.Combine(gameDirectory, gameName)))
         {
            MessageBox.Show($"Error finding {gameName}");
            gameDirectory = GetGameDirectory();
            if (!string.IsNullOrEmpty(gameDirectory))
            {
               gameName = File.Exists(Path.Combine(gameDirectory, "7DaysToDie.exe")) ?
                             "7DaysToDie.exe" :
                             "7DaysToDieServer.exe";

               if (File.Exists(Path.Combine(gameDirectory, gameName)))
               {
                  Configuration.SetValue("exe_dir", gameDirectory);
               }
            }
         }

         return new ValueTuple<string, string>(gameDirectory, gameName);
      }
   }

   /// <summary>
   ///    Copies the selected profile properties at sourcePath to the destinationPath
   /// </summary>
   /// <param name="sourcePath">Path of profile.xml</param>
   /// <param name="destinationPath">Location to paste</param>
   /// <returns></returns>
   public static async Task CopyFileAsync(string sourcePath, string destinationPath)
   {
      if (sourcePath == destinationPath)
      {
         return;
      }

      const int BufferSize = 81920; // Default buffer size for FileStream
      await using var sourceStream = new FileStream(
      sourcePath,
      FileMode.Open,
      FileAccess.Read,
      FileShare.Read,
      BufferSize,
      true);
      await using var destinationStream = new FileStream(
      destinationPath,
      FileMode.Create,
      FileAccess.Write,
      FileShare.None,
      BufferSize,
      true);
      await sourceStream.CopyToAsync(destinationStream);
   }

   /// <summary>
   ///    Launches the 7d2d.exe using the profile ID's server config profile
   /// </summary>
   /// <param name="profileID">Profile ID to use as serverconfig.xml</param>
   public static async Task LaunchAsync(int profileID)
   {
      var fullGamePath = GameFullPath;
      if (string.IsNullOrEmpty(fullGamePath.directory))
      {
         return;
      }

      var profileFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"profile{profileID}.xml");
      var destinationPath = Path.Combine(fullGamePath.directory, "newserverconfig.xml");

      // Perform asynchronous file copy
      await CopyFileAsync(profileFilePath, destinationPath);

      // Convert combobox values to integer values
      await RebuildConfigFileAsync(destinationPath);

      var logFile = Path.Combine(
      fullGamePath.directory,
      $"{fullGamePath.gameName.Replace(".exe", "")}_Data/OutputLog_{DateTime.Now:yy-MM-dd__HH-mm-ss}.txt");
      var command =
         $"start {fullGamePath.gameName} -logfile \"{logFile}\" -quit -batchmode -nographics -configfile=newserverconfig.xml -dedicated";

      // Launch the command in cmd prompt
      var processStartInfo = new ProcessStartInfo
                                {
                                   FileName = "cmd.exe",
                                   RedirectStandardInput = true,
                                   RedirectStandardOutput = false,
                                   RedirectStandardError = false,
                                   UseShellExecute = false,
                                   CreateNoWindow = false,
                                   WorkingDirectory = fullGamePath.directory
                                };

      using var process = new Process();
      process.StartInfo = processStartInfo;
      process.Start();

      // Write the command to cmd
      await using var writer = process.StandardInput;
      if (writer.BaseStream.CanWrite)
      {
         await writer.WriteLineAsync(command);
         await writer.WriteLineAsync("pause");
      }
   }

   /// <summary>
   ///    Provides a Dialogue box to direct the path of the GameDirectory to
   /// </summary>
   /// <returns></returns>
   private static string GetGameDirectory()
   {
      var gameDirectory = Configuration.GetValue("exe_dir");
      if (string.IsNullOrEmpty(gameDirectory))
      {
         var dir = ControlHelper.OpenFolderDialog("Select Your 7 Days To Die or Dedicated Server Root Game Folder");
         if (dir != null)
         {
            gameDirectory = dir;
            Configuration.SetValue("exe_dir", gameDirectory);
         }
      }

      return gameDirectory;
   }

   /// <summary>
   ///    Rewrites all the ComboBox property values to their index counterpart
   /// </summary>
   /// <param name="filePath">Location of the newserverconfig.xml</param>
   /// <returns></returns>
   private static async Task RebuildConfigFileAsync(string filePath)
   {
      var properties = XmlProfileParser.LoadPropertiesFromFile(filePath);
      foreach (var property in properties)
      {
         switch (property.Key)
         {
            case "ServerDisabledNetworkProtocols":
               var index = ComboBoxOptions.DisabledNetworkProtocols.IndexOf(property.Value);
               switch (index)
               {
                  case 0:
                     properties[property.Key] = "0";
                     break;
                  case 1:
                     properties[property.Key] = "SteamNetworking";
                     break;
                  case 2:
                     properties[property.Key] = "LiteNetLib";
                     break;
                  case 3:
                     properties[property.Key] = "SteamNetworking, LiteNetLib";
                     break;
               }

               break;

            case "ServerVisibility":
               properties[property.Key] = ComboBoxOptions.ServerVisibility.IndexOf(property.Value).ToString();
               break;
            case "HideCommandExecutionLog":
               properties[property.Key] = ComboBoxOptions.HideCommands.IndexOf(property.Value).ToString();
               break;
            case "EnemyDifficulty":
               properties[property.Key] = ComboBoxOptions.ZombieDifficulty.IndexOf(property.Value).ToString();
               break;
            case "GameDifficulty":
               properties[property.Key] = ComboBoxOptions.GameDifficulty.IndexOf(property.Value).ToString();
               break;
            case "DeathPenalty":
               properties[property.Key] = ComboBoxOptions.DeathPenalty.IndexOf(property.Value).ToString();
               break;
            case "DropOnDeath":
               properties[property.Key] = ComboBoxOptions.DropOnDeath.IndexOf(property.Value).ToString();
               break;
            case "DropOnQuit":
               properties[property.Key] = ComboBoxOptions.DropOnQuit.IndexOf(property.Value).ToString();
               break;
            case "PlayerKillingMode":
               properties[property.Key] = ComboBoxOptions.FriendlyFire.IndexOf(property.Value).ToString();
               break;
            case "ZombieBMMove":
               properties[property.Key] = ComboBoxOptions.ZombieMoveSpeed.IndexOf(property.Value).ToString();
               break;
            case "ZombieFeralMove":
               properties[property.Key] = ComboBoxOptions.ZombieMoveSpeed.IndexOf(property.Value).ToString();
               break;
            case "ZombieMove":
               properties[property.Key] = ComboBoxOptions.ZombieMoveSpeed.IndexOf(property.Value).ToString();
               break;
            case "ZombieMoveNight":
               properties[property.Key] = ComboBoxOptions.ZombieMoveSpeed.IndexOf(property.Value).ToString();
               break;
            case "ZombieFeralSense":
               properties[property.Key] = ComboBoxOptions.FeralSenseTimeOfDay.IndexOf(property.Value).ToString();
               break;
            case "LandClaimDecayMode":
               properties[property.Key] = ComboBoxOptions.LandClaimDecay.IndexOf(property.Value).ToString();
               break;
         }
      }

      await XmlProfileParser.SavePropertiesToFile(filePath, properties);
   }
}