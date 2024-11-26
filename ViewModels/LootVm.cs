namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Interfaces;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class LootVm : INotifyPropertyChanged, IControlData
{
   private string _abundance = "100";

   private string _airDropFreq = "3";

   private string _airDropMarker = "True";

   private string _daysTillRespawn = "7";

   public event PropertyChangedEventHandler? PropertyChanged;

   public string Abundance
   {
      get => _abundance;
      set
      {
         if (_abundance != value)
         {
            _abundance = value;
            OnPropertyChanged();
         }
      }
   }

   public string AirDropFreq
   {
      get => _airDropFreq;
      set
      {
         if (_airDropFreq != value)
         {
            _airDropFreq = value;
            OnPropertyChanged();
         }
      }
   }

   public string AirDropMarker
   {
      get => _airDropMarker;
      set
      {
         if (_airDropMarker != value)
         {
            _airDropMarker = value;
            OnPropertyChanged();
         }
      }
   }

   public string DaysTillRespawn
   {
      get => _daysTillRespawn;
      set
      {
         if (_daysTillRespawn != value)
         {
            _daysTillRespawn = value;
            OnPropertyChanged();
         }
      }
   }

   public Dictionary<string, string> GetMembers =>
      new Dictionary<string, string>
         {
            {"LootAbundance", _abundance},
            {"AirDropFrequency", _airDropFreq},
            {"AirDropMarker", _airDropMarker},
            {"LootRespawnDays", _daysTillRespawn}
         };

   public ObservableCollection<string> TrueFalseOptions { get; } = ["True", "False"];

   public void SetMembers(Dictionary<string, string> properties)
   {
      Abundance = properties["LootAbundance"];
      AirDropFreq = properties["AirDropFrequency"];
      AirDropMarker = properties["AirDropMarker"];
      DaysTillRespawn = properties["LootRespawnDays"];
   }

   private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }
}