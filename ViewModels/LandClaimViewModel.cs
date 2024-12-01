namespace _7D2D_ServerLauncher.ViewModels;

public class LandClaimViewModel : ViewModelBase
{
   private string _landClaimCount = "3";

   private string _landClaimDeadZone = "30";

   private string _landClaimDecayMode = "Slow";

   private string _landClaimExpiryTime = "7";

   private string _landClaimOfflineDelay = "0";

   private string _landClaimOfflineDurabilityModifier = "4";

   private string _landClaimOnlineDurabilityModifier = "4";

   private string _landClaimSize = "41";

   public string LandClaimCount
   {
      get => _landClaimCount;
      set
      {
         if (_landClaimCount != value)
         {
            _landClaimCount = value;
            SetProperty(nameof(LandClaimCount), value);
         }
      }
   }

   public string LandClaimDeadZone
   {
      get => _landClaimDeadZone;
      set
      {
         if (_landClaimDeadZone != value)
         {
            _landClaimDeadZone = value;
            SetProperty(nameof(LandClaimDeadZone), value);
         }
      }
   }

   public string LandClaimDecayMode
   {
      get => _landClaimDecayMode;
      set
      {
         if (_landClaimDecayMode != value)
         {
            _landClaimDecayMode = value;
            SetProperty(nameof(LandClaimDecayMode), value);
         }
      }
   }

   public string LandClaimExpiryTime
   {
      get => _landClaimExpiryTime;
      set
      {
         if (_landClaimExpiryTime != value)
         {
            _landClaimExpiryTime = value;
            SetProperty(nameof(LandClaimExpiryTime), value);
         }
      }
   }

   public string LandClaimOfflineDelay
   {
      get => _landClaimOfflineDelay;
      set
      {
         if (_landClaimOfflineDelay != value)
         {
            _landClaimOfflineDelay = value;
            SetProperty(nameof(LandClaimOfflineDelay), value);
         }
      }
   }

   public string LandClaimOfflineDurabilityModifier
   {
      get => _landClaimOfflineDurabilityModifier;
      set
      {
         if (_landClaimOfflineDurabilityModifier != value)
         {
            _landClaimOfflineDurabilityModifier = value;
            SetProperty(nameof(LandClaimOfflineDurabilityModifier), value);
         }
      }
   }

   public string LandClaimOnlineDurabilityModifier
   {
      get => _landClaimOnlineDurabilityModifier;
      set
      {
         if (_landClaimOnlineDurabilityModifier != value)
         {
            _landClaimOnlineDurabilityModifier = value;
            SetProperty(nameof(LandClaimOnlineDurabilityModifier), value);
         }
      }
   }

   public string LandClaimSize
   {
      get => _landClaimSize;
      set
      {
         if (_landClaimSize != value)
         {
            _landClaimSize = value;
            SetProperty(nameof(LandClaimSize), value);
         }
      }
   }
}