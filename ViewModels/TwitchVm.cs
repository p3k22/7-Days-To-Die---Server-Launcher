namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Interfaces;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class TwitchVm : INotifyPropertyChanged, IControlData
{
   private string _isAllowedBloodMoon = "False";

   private string _permissionLevel = "90";

   public event PropertyChangedEventHandler? PropertyChanged;

   public Dictionary<string, string> GetMembers =>
      new Dictionary<string, string>
         {
            {"TwitchBloodMoonAllowed", _isAllowedBloodMoon}, {"TwitchServerPermission", _permissionLevel}
         };

   public string IsAllowedBloodMoon
   {
      get => _isAllowedBloodMoon;
      set
      {
         if (_isAllowedBloodMoon != value)
         {
            _isAllowedBloodMoon = value;
            OnPropertyChanged();
         }
      }
   }

   public string PermissionLevel
   {
      get => _permissionLevel;
      set
      {
         if (_permissionLevel != value)
         {
            _permissionLevel = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> TrueFalseOptions { get; } = ["True", "False"];

   public void SetMembers(Dictionary<string, string> properties)
   {
      IsAllowedBloodMoon = properties["TwitchBloodMoonAllowed"];
      PermissionLevel = properties["TwitchServerPermission"];
   }

   private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }
}