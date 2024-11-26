namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Interfaces;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class WorldVm : INotifyPropertyChanged, IControlData
{
   private string _dayLength = "60";

   private string _dayLightLength = "18";

   private string _maxAnimals = "50";

   private string _maxDailyQuests = "3";

   private string _mode = "GameModeSurvival";

   private string _name = "My Game";

   private string _seed = "asdf";

   private string _size = "6144";

   private string _type = "RWG";

   public event PropertyChangedEventHandler? PropertyChanged;

   public string DayLength
   {
      get => _dayLength;
      set
      {
         if (_dayLength != value)
         {
            _dayLength = value;
            OnPropertyChanged();
         }
      }
   }

   public string DayLightLength
   {
      get => _dayLightLength;
      set
      {
         if (_dayLightLength != value)
         {
            _dayLightLength = value;
            OnPropertyChanged();
         }
      }
   }

   public Dictionary<string, string> GetMembers =>
      new Dictionary<string, string>
         {
            {"GameName", _name},
            {"WorldGenSeed", _seed},
            {"WorldGenSize", _size},
            {"GameWorld", _type},
            {"GameMode", _mode},
            {"QuestProgressionDailyLimit", _maxDailyQuests},
            {"MaxSpawnedAnimals", _maxAnimals},
            {"DayNightLength", _dayLength},
            {"DayLightLength", _dayLightLength}
         };

   public ObservableCollection<string> MapSizeOptions { get; } =
      [
         "2048", "4096", "6144", "8192", "10240"
      ];

   public ObservableCollection<string> MapTypeOptions { get; } =
      [
         "RWG", "Navezgane", "Pregen04k1", "Pregen04k2", "Pregen04k3", "Pregen04k4", "Pregen06k1", "Pregen06k2",
         "Pregen06k3", "Pregen06k4", "Pregen08k1", "Pregen08k2", "Pregen08k3", "Pregen08k4", "Pregen10k1", "Pregen10k2",
         "Pregen10k3", "Pregen10k4"
      ];

   public string MaxAnimals
   {
      get => _maxAnimals;
      set
      {
         if (_maxAnimals != value)
         {
            _maxAnimals = value;
            OnPropertyChanged();
         }
      }
   }

   public string MaxDailyQuests
   {
      get => _maxDailyQuests;
      set
      {
         if (_maxDailyQuests != value)
         {
            _maxDailyQuests = value;
            OnPropertyChanged();
         }
      }
   }

   public string Mode
   {
      get => _mode;
      set
      {
         if (_mode != value)
         {
            _mode = value;
            OnPropertyChanged();
         }
      }
   }

   public string Name
   {
      get => _name;
      set
      {
         if (value.Length > 50)
         {
            return;
         }

         if (_name != value)
         {
            _name = value;
            OnPropertyChanged();
         }
      }
   }

   public string Seed
   {
      get => _seed;
      set
      {
         if (value.Length > 50)
         {
            return;
         }

         if (_seed != value)
         {
            _seed = value;
            OnPropertyChanged();
         }
      }
   }

   public string Size
   {
      get => _size;
      set
      {
         if (_size != value)
         {
            _size = value;
            OnPropertyChanged();
         }
      }
   }

   public string Type
   {
      get => _type;
      set
      {
         if (_type != value)
         {
            _type = value;
            OnPropertyChanged();
         }
      }
   }

   public void SetMembers(Dictionary<string, string> properties)
   {
      Name = properties["GameName"];
      Seed = properties["WorldGenSeed"];
      Size = properties["WorldGenSize"];
      Type = properties["GameWorld"];
      Mode = properties["GameMode"];
      MaxDailyQuests = properties["QuestProgressionDailyLimit"];
      MaxAnimals = properties["MaxSpawnedAnimals"];
      DayLength = properties["DayNightLength"];
      DayLightLength = properties["DayLightLength"];
   }

   private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }
}