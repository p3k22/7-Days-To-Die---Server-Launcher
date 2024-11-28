namespace _7D2D_ServerLauncher.ViewModels;

using System.Reflection;

public class BloodMoonVm : BaseViewModel
{
   public BloodMoonVm()
   {
      // Collect and register properties
      var properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
      RegisterProperties(properties);
   }

   private string _dayRange = "0";

   private string _frequency = "7";

   private string _hoursWarning = "8";

   private string _maxSpawnedZombie = "8";

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

   //TODO -- Carry on extending all VMs from BaseVM.  Get and set properties is now centralised
   //public event PropertyChangedEventHandler? PropertyChanged;
   //public Dictionary<string, string> GetMembers =>
   //   new Dictionary<string, string>
   //      {
   //         {"BloodMoonRange", _dayRange},
   //         {"BloodMoonFrequency", _frequency},
   //         {"BloodMoonWarning", _hoursWarning},
   //         {"BloodMoonEnemyCount", _maxSpawnedZombie}
   //      };

   //public void SetMembers(Dictionary<string, string> properties)
   //{
   //   DayRange = properties["BloodMoonRange"];
   //   Frequency = properties["BloodMoonFrequency"];
   //   HoursWarning = properties["BloodMoonWarning"];
   //   MaxSpawnedZombie = properties["BloodMoonEnemyCount"];
   //}

   //private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   //{
   //   PropertyChanged?.Invoke(this, new(propertyName));
   //}
}