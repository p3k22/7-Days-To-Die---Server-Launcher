namespace _7D2D_ServerLauncher.ViewModels;

public class LootViewModel : ViewModelBase
{
   private string _airDropFrequency = "3";

   private string _airDropMarker = "True";

   private string _lootAbundance = "100";

   private string _lootRespawnDays = "7";

   public string AirDropFrequency
   {
      get => _airDropFrequency;
      set
      {
         if (_airDropFrequency != value)
         {
            _airDropFrequency = value;
            SetProperty(nameof(AirDropFrequency), value);
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
            SetProperty(nameof(AirDropMarker), value);
         }
      }
   }

   public string LootAbundance
   {
      get => _lootAbundance;
      set
      {
         if (_lootAbundance != value)
         {
            _lootAbundance = value;
            SetProperty(nameof(LootAbundance), value);
         }
      }
   }

   public string LootRespawnDays
   {
      get => _lootRespawnDays;
      set
      {
         if (_lootRespawnDays != value)
         {
            _lootRespawnDays = value;
            SetProperty(nameof(LootRespawnDays), value);
         }
      }
   }
}