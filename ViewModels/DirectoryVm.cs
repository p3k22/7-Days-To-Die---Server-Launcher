namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Interfaces;

using System.ComponentModel;
using System.Runtime.CompilerServices;

public class DirectoryVm : INotifyPropertyChanged, IControlData
{
   private string _adminFile = "serveradmin.xml";

   private string _customDir = "";

   public event PropertyChangedEventHandler? PropertyChanged;

   public string AdminFile
   {
      get => _adminFile;
      set
      {
         if (_adminFile != value)
         {
            _adminFile = value;
            OnPropertyChanged();
         }
      }
   }

   public string CustomDirectory
   {
      get => _customDir;
      set
      {
         if (_customDir != value)
         {
            _customDir = value;
            OnPropertyChanged();
         }
      }
   }

   public Dictionary<string, string> GetMembers =>
      new Dictionary<string, string> {{"UserDataFolder", _customDir}, {"AdminFileName", _adminFile}};

   public void SetMembers(Dictionary<string, string> properties)
   {
      properties.TryGetValue("UserDataFolder", out var custDir);
      CustomDirectory = custDir ?? "";
      AdminFile = properties["AdminFileName"];
   }

   private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }
}