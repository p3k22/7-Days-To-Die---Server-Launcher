namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Interfaces;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class LandClaimVm : INotifyPropertyChanged, IControlData
{
   private string _claimSize = "41";

   private string _deadZone = "30";

   private string _decayMode = "Slow";

   private string _expiryTime = "7";

   private string _maxClaims = "3";

   private string _offlineDelay = "0";

   private string _offlineDurability = "4";

   private string _onlineDurability = "4";

   public event PropertyChangedEventHandler? PropertyChanged;

   public string ClaimSize
   {
      get => _claimSize;
      set
      {
         if (_claimSize != value)
         {
            _claimSize = value;
            OnPropertyChanged();
         }
      }
   }

   public string DeadZone
   {
      get => _deadZone;
      set
      {
         if (_deadZone != value)
         {
            _deadZone = value;
            OnPropertyChanged();
         }
      }
   }

   public string DecayMode
   {
      get => _decayMode;
      set
      {
         if (_decayMode != value)
         {
            _decayMode = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> DecayModeOptions { get; } = ["Slow", "Fast", "None"];

   public string ExpiryTime
   {
      get => _expiryTime;
      set
      {
         if (_expiryTime != value)
         {
            _expiryTime = value;
            OnPropertyChanged();
         }
      }
   }

   public Dictionary<string, string> GetMembers =>
      new Dictionary<string, string>
         {
            {"LandClaimSize", _claimSize},
            {"LandClaimDeadZone", _deadZone},
            {"LandClaimDecayMode", DecayModeOptions.IndexOf(_decayMode).ToString()},
            {"LandClaimExpiryTime", _expiryTime},
            {"LandClaimCount", _maxClaims},
            {"LandClaimOfflineDelay", _offlineDelay},
            {"LandClaimOfflineDurabilityModifier", _offlineDurability},
            {"LandClaimOnlineDurabilityModifier", _onlineDurability}
         };

   public string MaxClaims
   {
      get => _maxClaims;
      set
      {
         if (_maxClaims != value)
         {
            _maxClaims = value;
            OnPropertyChanged();
         }
      }
   }

   public string OfflineDelay
   {
      get => _offlineDelay;
      set
      {
         if (_offlineDelay != value)
         {
            _offlineDelay = value;
            OnPropertyChanged();
         }
      }
   }

   public string OfflineDurability
   {
      get => _offlineDurability;
      set
      {
         if (_offlineDurability != value)
         {
            _offlineDurability = value;
            OnPropertyChanged();
         }
      }
   }

   public string OnlineDurability
   {
      get => _onlineDurability;
      set
      {
         if (_onlineDurability != value)
         {
            _onlineDurability = value;
            OnPropertyChanged();
         }
      }
   }

   public void SetMembers(Dictionary<string, string> properties)
   {
      ClaimSize = properties["LandClaimSize"];
      DeadZone = properties["LandClaimDeadZone"];
      DecayMode = properties["LandClaimDecayMode"];
      ExpiryTime = properties["LandClaimExpiryTime"];
      MaxClaims = properties["LandClaimCount"];
      OfflineDelay = properties["LandClaimOfflineDelay"];
      OfflineDurability = properties["LandClaimOfflineDurabilityModifier"];
      OnlineDurability = properties["LandClaimOnlineDurabilityModifier"];
   }

   private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }
}