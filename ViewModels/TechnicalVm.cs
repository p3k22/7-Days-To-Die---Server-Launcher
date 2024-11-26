namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Interfaces;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class TechnicalVm : INotifyPropertyChanged, IControlData
{
   private string _hideCommandLog = "None";

   private string _isEacEnabled = "True";

   private string _isIgnoringEacSanctions = "True";

   private string _isPersistentProfiles = "False";

   private string _maxChunkAge = "-1";

   private string _maxUncoveredChunks = "131072";

   private string _saveLimit = "-1";

   public event PropertyChangedEventHandler? PropertyChanged;

   public Dictionary<string, string> GetMembers =>
      new Dictionary<string, string>
         {
            {"HideCommandExecutionLog", HideCommandOptions.IndexOf(_hideCommandLog).ToString()},
            {"EACEnabled", _isEacEnabled},
            {"IgnoreEOSSanctions", _isIgnoringEacSanctions},
            {"PersistentPlayerProfiles", _isPersistentProfiles},
            {"MaxChunkAge", _maxChunkAge},
            {"MaxUncoveredMapChunksPerPlayer", _maxUncoveredChunks},
            {"SaveDataLimit", _saveLimit}
         };

   public string HideCommandLog
   {
      get => _hideCommandLog;
      set
      {
         if (_hideCommandLog != value)
         {
            _hideCommandLog = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> HideCommandOptions { get; } =
         ["None", "Telnet/ControlPanel", "Telnet/ControlPanel/Remote", "Everything"];

   public string IsEacEnabled
   {
      get => _isEacEnabled;
      set
      {
         if (_isEacEnabled != value)
         {
            _isEacEnabled = value;
            OnPropertyChanged();
         }
      }
   }

   public string IsIgnoringEacSanctions
   {
      get => _isIgnoringEacSanctions;
      set
      {
         if (_isIgnoringEacSanctions != value)
         {
            _isIgnoringEacSanctions = value;
            OnPropertyChanged();
         }
      }
   }

   public string IsPersistentProfiles
   {
      get => _isPersistentProfiles;
      set
      {
         if (_isPersistentProfiles != value)
         {
            _isPersistentProfiles = value;
            OnPropertyChanged();
         }
      }
   }

   public string MaxChunkAge
   {
      get => _maxChunkAge;
      set
      {
         if (_maxChunkAge != value)
         {
            _maxChunkAge = value;
            OnPropertyChanged();
         }
      }
   }

   public string MaxUncoveredChunks
   {
      get => _maxUncoveredChunks;
      set
      {
         if (_maxUncoveredChunks != value)
         {
            _maxUncoveredChunks = value;
            OnPropertyChanged();
         }
      }
   }

   public string SaveLimit
   {
      get => _saveLimit;
      set
      {
         if (_saveLimit != value)
         {
            _saveLimit = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> TrueFalseOptions { get; } = ["True", "False"];

   public void SetMembers(Dictionary<string, string> properties)
   {
      HideCommandLog = properties["HideCommandExecutionLog"];
      IsEacEnabled = properties["EACEnabled"];
      IsIgnoringEacSanctions = properties["IgnoreEOSSanctions"];
      IsPersistentProfiles = properties["PersistentPlayerProfiles"];
      MaxChunkAge = properties["MaxChunkAge"];
      MaxUncoveredChunks = properties["MaxUncoveredMapChunksPerPlayer"];
      SaveLimit = properties["SaveDataLimit"];
   }

   private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }
}