namespace _7D2D_ServerLauncher.ViewModels;

public class PlayerViewModel : ViewModelBase
{
   private string _bedrollDeadZoneSize = "15";

   private string _bedrollExpiryTime = "45";

   private string _blockDamagePlayer = "100";

   private string _deathPenalty = "XP Only";

   private string _dropOnDeath = "Everything";

   private string _dropOnQuit = "Nothing";

   private string _partySharedKillRange = "100";

   private string _playerKillingMode = "Kill Strangers Only";

   private string _playerSafeZoneHours = "5";

   private string _playerSafeZoneLevel = "5";

   public string BedrollDeadZoneSize
   {
      get => _bedrollDeadZoneSize;
      set
      {
         if (_bedrollDeadZoneSize != value)
         {
            _bedrollDeadZoneSize = value;
            SetProperty(nameof(BedrollDeadZoneSize), value);
         }
      }
   }

   public string BedrollExpiryTime
   {
      get => _bedrollExpiryTime;
      set
      {
         if (_bedrollExpiryTime != value)
         {
            _bedrollExpiryTime = value;
            SetProperty(nameof(BedrollExpiryTime), value);
         }
      }
   }

   public string BlockDamagePlayer
   {
      get => _blockDamagePlayer;
      set
      {
         if (_blockDamagePlayer != value)
         {
            _blockDamagePlayer = value;
            SetProperty(nameof(BlockDamagePlayer), value);
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
            SetProperty(nameof(DeathPenalty), value);
         }
      }
   }

   public string DropOnDeath
   {
      get => _dropOnDeath;
      set
      {
         if (_dropOnDeath != value)
         {
            _dropOnDeath = value;
            SetProperty(nameof(DropOnDeath), value);
         }
      }
   }

   public string DropOnQuit
   {
      get => _dropOnQuit;
      set
      {
         if (_dropOnQuit != value)
         {
            _dropOnQuit = value;
            SetProperty(nameof(DropOnQuit), value);
         }
      }
   }

   public string PartySharedKillRange
   {
      get => _partySharedKillRange;
      set
      {
         if (_partySharedKillRange != value)
         {
            _partySharedKillRange = value;
            SetProperty(nameof(PartySharedKillRange), value);
         }
      }
   }

   public string PlayerKillingMode
   {
      get => _playerKillingMode;
      set
      {
         if (_playerKillingMode != value)
         {
            _playerKillingMode = value;
            SetProperty(nameof(PlayerKillingMode), value);
         }
      }
   }

   public string PlayerSafeZoneHours
   {
      get => _playerSafeZoneHours;
      set
      {
         if (_playerSafeZoneHours != value)
         {
            _playerSafeZoneHours = value;
            SetProperty(nameof(PlayerSafeZoneHours), value);
         }
      }
   }

   public string PlayerSafeZoneLevel
   {
      get => _playerSafeZoneLevel;
      set
      {
         if (_playerSafeZoneLevel != value)
         {
            _playerSafeZoneLevel = value;
            SetProperty(nameof(PlayerSafeZoneLevel), value);
         }
      }
   }
}