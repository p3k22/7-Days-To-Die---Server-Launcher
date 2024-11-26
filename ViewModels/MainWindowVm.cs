namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Cursor;
using _7D2D_ServerLauncher.Helpers;
using _7D2D_ServerLauncher.Interfaces;

using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

public class MainWindowVm
{
   private ConfigManager _configManager =
      new ConfigManager(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "7d2dsl.config"));

   private string _gameDirectory;

   private Window _uiWindow;

   public MainWindowVm(Window uiWindow)
   {
      _uiWindow = uiWindow;
      CustomCursor.SetCursor(uiWindow);
      InitializeConfig();
   }

   public int SelectedProfileID { get; private set; }

   public Dictionary<string, string> GetDataFromAllFields()
   {
      var data = new Dictionary<string, string>();
      var contentControls = ControlHelper.GetAllControlsOfType<ContentControl>(_uiWindow);

      foreach (var control in contentControls)
      {
         if (control.DataContext is IControlData fieldData)
         {
            foreach (var member in fieldData.GetMembers)
            {
               data[member.Key] = member.Value;
            }
         }
      }

      return data;
   }

   public string GetProfileName(int profID)
   {
      return _configManager.GetValue($"profile_{profID}_name");
   }

   public void LaunchServer()
   {
      var gameName = File.Exists(Path.Combine(_gameDirectory, "7DaysToDie.exe")) ?
                        "7DaysToDie.exe" :
                        "7DaysToDieServer.exe";

      if (!File.Exists(Path.Combine(_gameDirectory, gameName)))
      {
         MessageBox.Show($"Error finding {gameName}");
         var dir = ControlHelper.OpenFolderDialog("Select Your 7 Days To Die or Dedicated Server Root Game Folder");
         if (dir != null)
         {
            _gameDirectory = dir;

            gameName = File.Exists(Path.Combine(_gameDirectory, "7DaysToDie.exe")) ?
                          "7DaysToDie.exe" :
                          "7DaysToDieServer.exe";

            if (File.Exists(Path.Combine(_gameDirectory, gameName)))
            {
               _configManager.SetValue("exe_dir", dir);
            }
            else
            {
               MessageBox.Show("You so funny");
               return;
            }
         }
         else
         {
            MessageBox.Show("You so funny");
            return;
         }
      }

      var profileFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"profile{SelectedProfileID}.xml");
      File.Copy(profileFilePath, _gameDirectory + "\\newserverconfig.xml", true);

      var logFile = Path.Combine(
      _gameDirectory,
      $"{gameName.Replace(".exe", "")}_Data/OutputLog_{DateTime.Now:yy-MM-dd__HH-mm-ss}.txt");
      var command =
         $"start {gameName} -logfile \"{logFile}\" -quit -batchmode -nographics -configfile=newserverconfig.xml -dedicated";

      // Launch the command in cmd prompt
      var processStartInfo = new ProcessStartInfo
                                {
                                   FileName = "cmd.exe",
                                   RedirectStandardInput = true,
                                   RedirectStandardOutput = false,
                                   RedirectStandardError = false,
                                   UseShellExecute = false,
                                   CreateNoWindow = false,
                                   WorkingDirectory = _gameDirectory
                                };

      using var process = new Process();
      process.StartInfo = processStartInfo;
      process.Start();

      // Write the command to cmd
      using var writer = process.StandardInput;
      if (writer.BaseStream.CanWrite)
      {
         writer.WriteLine(command);
         writer.WriteLine("pause");
      }
   }

   public void SaveProfileName(int profID, string name)
   {
      _configManager.SetValue($"profile_{profID}_name", name);
   }

   public async Task SetDataToAllFields(string profileFilePath)
   {
      var properties = new Dictionary<string, string>();

      var xmlDoc = XDocument.Parse(await File.ReadAllTextAsync(profileFilePath));
      foreach (var property in xmlDoc.Descendants("property"))
      {
         var name = property.Attribute("name")?.Value;
         var value = property.Attribute("value")?.Value;
         if (name != null)
         {
            properties[name] = value!;
         }
      }

      var contentControls = ControlHelper.GetAllControlsOfType<ContentControl>(_uiWindow);
      foreach (var fieldData in contentControls.Select(control => control.DataContext as IControlData))
      {
         fieldData?.SetMembers(properties);
      }
   }

   public void SetSelectedProfileID(int id)
   {
      _configManager.SetValue("selected_prof_id", id.ToString());
      SelectedProfileID = id;
   }

   private void InitializeConfig()
   {
      _gameDirectory = _configManager.GetValue("exe_dir");
      if (string.IsNullOrEmpty(_gameDirectory))
      {
         var dir = ControlHelper.OpenFolderDialog("Select Your 7 Days To Die or Dedicated Server Root Game Folder");
         if (dir != null)
         {
            _gameDirectory = dir;
            _configManager.SetValue("exe_dir", dir);
         }
      }

      var id = 0;
      var idFromFile = _configManager.GetValue("selected_prof_id");
      if (!string.IsNullOrEmpty(idFromFile))
      {
         int.TryParse(idFromFile, out id);
      }

      SelectedProfileID = id;
   }
}