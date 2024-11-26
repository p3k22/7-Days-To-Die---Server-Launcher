namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Interfaces;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class PlayerVm : INotifyPropertyChanged, IControlData
{
   private string _bedrollDeadZoneSize = "15";

   private string _bedrollExpiry = "45";

   private string _blockDamage = "100";

   private string _deathPenalty = "XP Only";

   private string _dropOnDeath = "Everything";

   private string _dropOnQuit = "Nothing";

   private string _friendlyFire = "Kill Strangers Only";

   private string _safeZoneHours = "5";

   private string _safeZoneLevel = "5";

   private string _sharedKillRange = "100";

   public event PropertyChangedEventHandler? PropertyChanged;

   public string BedrollDeadZoneSize
   {
      get => _bedrollDeadZoneSize;
      set
      {
         if (_bedrollDeadZoneSize != value)
         {
            _bedrollDeadZoneSize = value;
            OnPropertyChanged();
         }
      }
   }

   public string BedrollExpiry
   {
      get => _bedrollExpiry;
      set
      {
         if (_bedrollExpiry != value)
         {
            _bedrollExpiry = value;
            OnPropertyChanged();
         }
      }
   }

   public string BlockDamage
   {
      get => _blockDamage;
      set
      {
         if (_blockDamage != value)
         {
            _blockDamage = value;
            OnPropertyChanged();
         }
      }
   }

   public string DeathPenalty
   {
      get => _deathPenalty;
      set
      {
         if (_deathPenalty != value)
         {
            _deathPenalty = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> DeathPenaltyOptions { get; } =
         ["Nothing", "XP Only", "Injured", "Permanent Death"];

   public string DropOnDeath
   {
      get => _dropOnDeath;
      set
      {
         if (_dropOnDeath != value)
         {
            _dropOnDeath = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> DropOnDeathOptions { get; } =
         ["Nothing", "Everything", "Toolbelt Only", "Backpack Only", "Delete All"];

   public string DropOnQuit
   {
      get => _dropOnQuit;
      set
      {
         if (_dropOnQuit != value)
         {
            _dropOnQuit = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> DropOnQuitOptions { get; } =
         ["Nothing", "Everything", "Toolbelt Only", "Backpack Only"];

   public string FriendlyFire
   {
      get => _friendlyFire;
      set
      {
         if (_friendlyFire != value)
         {
            _friendlyFire = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> FriendlyFireOptions { get; } =
         ["No Killing", "Kill Allies Only", "Kill Strangers Only", "Kill Everyone"];

   public Dictionary<string, string> GetMembers =>
      new Dictionary<string, string>
         {
            {"BedrollDeadZoneSize", _bedrollDeadZoneSize},
            {"BedrollExpiryTime", _bedrollExpiry},
            {"BlockDamagePlayer", _blockDamage},
            {"DeathPenalty", DeathPenaltyOptions.IndexOf(_deathPenalty).ToString()},
            {"DropOnDeath", DropOnDeathOptions.IndexOf(_dropOnDeath).ToString()},
            {"DropOnQuit", DropOnQuitOptions.IndexOf(_dropOnQuit).ToString()},
            {"PlayerKillingMode", FriendlyFireOptions.IndexOf(_friendlyFire).ToString()},
            {"PlayerSafeZoneHours", _safeZoneHours},
            {"PlayerSafeZoneLevel", _safeZoneLevel},
            {"PartySharedKillRange", _sharedKillRange}
         };

   public string SafeZoneHours
   {
      get => _safeZoneHours;
      set
      {
         if (_safeZoneHours != value)
         {
            _safeZoneHours = value;
            OnPropertyChanged();
         }
      }
   }

   public string SafeZoneLevel
   {
      get => _safeZoneLevel;
      set
      {
         if (_safeZoneLevel != value)
         {
            _safeZoneLevel = value;
            OnPropertyChanged();
         }
      }
   }

   public string SharedKillRange
   {
      get => _sharedKillRange;
      set
      {
         if (_sharedKillRange != value)
         {
            _sharedKillRange = value;
            OnPropertyChanged();
         }
      }
   }

   public void SetMembers(Dictionary<string, string> properties)
   {
      BedrollDeadZoneSize = properties["BedrollDeadZoneSize"];
      BedrollExpiry = properties["BedrollExpiryTime"];
      BlockDamage = properties["BlockDamagePlayer"];
      DeathPenalty = properties["DeathPenalty"];
      DropOnDeath = properties["DropOnDeath"];
      DropOnQuit = properties["DropOnQuit"];
      FriendlyFire = properties["PlayerKillingMode"];
      SafeZoneHours = properties["PlayerSafeZoneHours"];
      SafeZoneLevel = properties["PlayerSafeZoneLevel"];
      SharedKillRange = properties["PartySharedKillRange"];
   }

   private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }
}