namespace _7D2D_ServerLauncher.ViewModels;

public class TechnicalViewModel : ViewModelBase
{
   private string _eacEnabled = "True";

   private string _hideCommandExecutionLog = "None";

   private string _ignoreEosSanctions = "True";

   private string _maxChunkAge = "-1";

   private string _maxUncoveredMapChunksPerPlayer = "131072";

   private string _persistentPlayerProfiles = "False";

   private string _saveDataLimit = "-1";

   public string EACEnabled
   {
      get => _eacEnabled;
      set
      {
         if (_eacEnabled != value)
         {
            _eacEnabled = value;
            SetProperty(nameof(EACEnabled), value);
         }
      }
   }

   public string HideCommandExecutionLog
   {
      get => _hideCommandExecutionLog;
      set
      {
         if (_hideCommandExecutionLog != value)
         {
            _hideCommandExecutionLog = value;
            SetProperty(nameof(HideCommandExecutionLog), value);
         }
      }
   }

   public string IgnoreEOSSanctions
   {
      get => _ignoreEosSanctions;
      set
      {
         if (_ignoreEosSanctions != value)
         {
            _ignoreEosSanctions = value;
            SetProperty(nameof(IgnoreEOSSanctions), value);
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
            SetProperty(nameof(MaxChunkAge), value);
         }
      }
   }

   public string MaxUncoveredMapChunksPerPlayer
   {
      get => _maxUncoveredMapChunksPerPlayer;
      set
      {
         if (_maxUncoveredMapChunksPerPlayer != value)
         {
            _maxUncoveredMapChunksPerPlayer = value;
            SetProperty(nameof(MaxUncoveredMapChunksPerPlayer), value);
         }
      }
   }

   public string PersistentPlayerProfiles
   {
      get => _persistentPlayerProfiles;
      set
      {
         if (_persistentPlayerProfiles != value)
         {
            _persistentPlayerProfiles = value;
            SetProperty(nameof(PersistentPlayerProfiles), value);
         }
      }
   }

   public string SaveDataLimit
   {
      get => _saveDataLimit;
      set
      {
         if (_saveDataLimit != value)
         {
            _saveDataLimit = value;
            SetProperty(nameof(SaveDataLimit), value);
         }
      }
   }
}