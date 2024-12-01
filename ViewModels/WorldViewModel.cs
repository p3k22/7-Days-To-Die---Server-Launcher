namespace _7D2D_ServerLauncher.ViewModels;

public class WorldViewModel : ViewModelBase
{
   private string _dayLightLength = "18";

   private string _dayNightLength = "60";

   private string _gameMode = "GameModeSurvival";

   private string _gameName = "My Game";

   private string _gameWorld = "RWG";

   private string _maxSpawnedAnimals = "50";

   private string _questProgressionDailyLimit = "3";

   private string _worldGenSeed = "asdf";

   private string _worldGenSize = "6144";

   public string DayLightLength
   {
      get => _dayLightLength;
      set
      {
         if (_dayLightLength != value)
         {
            _dayLightLength = value;
            SetProperty(nameof(DayLightLength), value);
         }
      }
   }

   public string DayNightLength
   {
      get => _dayNightLength;
      set
      {
         if (_dayNightLength != value)
         {
            _dayNightLength = value;
            SetProperty(nameof(DayNightLength), value);
         }
      }
   }

   public string GameMode
   {
      get => _gameMode;
      set
      {
         if (_gameMode != value)
         {
            _gameMode = value;
            SetProperty(nameof(GameMode), value);
         }
      }
   }

   public string GameName
   {
      get => _gameName;
      set
      {
         if (value.Length > 50)
         {
            return;
         }

         if (_gameName != value)
         {
            _gameName = value;
            SetProperty(nameof(GameName), value);
         }
      }
   }

   public string GameWorld
   {
      get => _gameWorld;
      set
      {
         if (_gameWorld != value)
         {
            _gameWorld = value;
            SetProperty(nameof(GameWorld), value);
         }
      }
   }

   public string MaxSpawnedAnimals
   {
      get => _maxSpawnedAnimals;
      set
      {
         if (_maxSpawnedAnimals != value)
         {
            _maxSpawnedAnimals = value;
            SetProperty(nameof(MaxSpawnedAnimals), value);
         }
      }
   }

   public string QuestProgressionDailyLimit
   {
      get => _questProgressionDailyLimit;
      set
      {
         if (_questProgressionDailyLimit != value)
         {
            _questProgressionDailyLimit = value;
            SetProperty(nameof(QuestProgressionDailyLimit), value);
         }
      }
   }

   public string WorldGenSeed
   {
      get => _worldGenSeed;
      set
      {
         if (value.Length > 50)
         {
            return;
         }

         if (_worldGenSeed != value)
         {
            _worldGenSeed = value;
            SetProperty(nameof(WorldGenSeed), value);
         }
      }
   }

   public string WorldGenSize
   {
      get => _worldGenSize;
      set
      {
         if (_worldGenSize != value)
         {
            _worldGenSize = value;
            SetProperty(nameof(WorldGenSize), value);
         }
      }
   }
}