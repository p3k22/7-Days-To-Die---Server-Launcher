namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Interfaces;

using System.ComponentModel;
using System.Runtime.CompilerServices;

public class BloodMoonVm : INotifyPropertyChanged, IControlData
{
   private string _dayRange = "0";

   private string _frequency = "7";

   private string _hoursWarning = "8";

   private string _maxSpawnedZombie = "8";

   public event PropertyChangedEventHandler? PropertyChanged;

   public string DayRange
   {
      get => _dayRange;
      set
      {
         if (_dayRange != value)
         {
            _dayRange = value;
            OnPropertyChanged();
         }
      }
   }

   public string Frequency
   {
      get => _frequency;
      set
      {
         if (_frequency != value)
         {
            _frequency = value;
            OnPropertyChanged();
         }
      }
   }

   public Dictionary<string, string> GetMembers =>
      new Dictionary<string, string>
         {
            {"BloodMoonRange", _dayRange},
            {"BloodMoonFrequency", _frequency},
            {"BloodMoonWarning", _hoursWarning},
            {"BloodMoonEnemyCount", _maxSpawnedZombie}
         };

   public string HoursWarning
   {
      get => _hoursWarning;
      set
      {
         if (_hoursWarning != value)
         {
            _hoursWarning = value;
            OnPropertyChanged();
         }
      }
   }

   public string MaxSpawnedZombie
   {
      get => _maxSpawnedZombie;
      set
      {
         if (_maxSpawnedZombie != value)
         {
            _maxSpawnedZombie = value;
            OnPropertyChanged();
         }
      }
   }

   public void SetMembers(Dictionary<string, string> properties)
   {
      DayRange = properties["BloodMoonRange"];
      Frequency = properties["BloodMoonFrequency"];
      HoursWarning = properties["BloodMoonWarning"];
      MaxSpawnedZombie = properties["BloodMoonEnemyCount"];
   }

   private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }
}