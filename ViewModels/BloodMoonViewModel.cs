namespace _7D2D_ServerLauncher.ViewModels;

public class BloodMoonViewModel : ViewModelBase
{
   private string _bloodMoonEnemyCount = "8";

   private string _bloodMoonFrequency = "7";

   private string _bloodMoonRange = "0";

   private string _bloodMoonWarning = "8";

   public string BloodMoonEnemyCount
   {
      get => _bloodMoonEnemyCount;
      set
      {
         if (_bloodMoonEnemyCount != value)
         {
            _bloodMoonEnemyCount = value;
            SetProperty(nameof(BloodMoonEnemyCount), value);
         }
      }
   }

   public string BloodMoonFrequency
   {
      get => _bloodMoonFrequency;
      set
      {
         if (_bloodMoonFrequency != value)
         {
            _bloodMoonFrequency = value;
            SetProperty(nameof(BloodMoonFrequency), value);
         }
      }
   }

   public string BloodMoonRange
   {
      get => _bloodMoonRange;
      set
      {
         if (_bloodMoonRange != value)
         {
            _bloodMoonRange = value;
            SetProperty(nameof(BloodMoonRange), value);
         }
      }
   }

   public string BloodMoonWarning
   {
      get => _bloodMoonWarning;
      set
      {
         if (_bloodMoonWarning != value)
         {
            _bloodMoonWarning = value;
            SetProperty(nameof(BloodMoonWarning), value);
         }
      }
   }
}