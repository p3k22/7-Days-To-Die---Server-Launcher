namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Interfaces;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class ZombieVm : INotifyPropertyChanged, IControlData
{
   private string _blockDamage = "100";

   private string _blockDamageBloodMoon = "100";

   private string _feralSenseTimeOfDay = "Off";

   private string _isSpawningEnabled = "True";

   private string _maxSpawnedZombies = "64";

   private string _moveSpeedBloodMoon = "Sprint";

   private string _moveSpeedDayTime = "Walk";

   private string _moveSpeedFeral = "Sprint";

   private string _moveSpeedNightTime = "Sprint";

   public event PropertyChangedEventHandler? PropertyChanged;

   public string BlockDamage
   {
      get => _blockDamage;
      set
      {
         if (_blockDamage != value)
         {
            _blockDamage = value;
            OnPropertyChanged();
         }
      }
   }

   public string BlockDamageBloodMoon
   {
      get => _blockDamageBloodMoon;
      set
      {
         if (_blockDamageBloodMoon != value)
         {
            _blockDamageBloodMoon = value;
            OnPropertyChanged();
         }
      }
   }

   public string FeralSenseTimeOfDay
   {
      get => _feralSenseTimeOfDay;
      set
      {
         if (_feralSenseTimeOfDay != value)
         {
            _feralSenseTimeOfDay = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> FeralSenseTodOptions { get; } = ["Off", "Day", "Night", "All"];

   public Dictionary<string, string> GetMembers =>
      new Dictionary<string, string>
         {
            {"BlockDamageAI", _blockDamage},
            {"BlockDamageAIBM", _blockDamageBloodMoon},
            {"ZombieFeralSense", FeralSenseTodOptions.IndexOf(_feralSenseTimeOfDay).ToString()},
            {"EnemySpawnMode", _isSpawningEnabled},
            {"MaxSpawnedZombies", _maxSpawnedZombies},
            {"ZombieBMMove", MoveSpeedOptions.IndexOf(_moveSpeedBloodMoon).ToString()},
            {"ZombieMove", MoveSpeedOptions.IndexOf(_moveSpeedDayTime).ToString()},
            {"ZombieFeralMove", MoveSpeedOptions.IndexOf(_moveSpeedFeral).ToString()},
            {"ZombieMoveNight", MoveSpeedOptions.IndexOf(_moveSpeedNightTime).ToString()}
         };

   public string IsSpawningEnabled
   {
      get => _isSpawningEnabled;
      set
      {
         if (_isSpawningEnabled != value)
         {
            _isSpawningEnabled = value;
            OnPropertyChanged();
         }
      }
   }

   public string MaxSpawnedZombies
   {
      get => _maxSpawnedZombies;
      set
      {
         if (_maxSpawnedZombies != value)
         {
            _maxSpawnedZombies = value;
            OnPropertyChanged();
         }
      }
   }

   public string MoveSpeedBloodMoon
   {
      get => _moveSpeedBloodMoon;
      set
      {
         if (_moveSpeedBloodMoon != value)
         {
            _moveSpeedBloodMoon = value;
            OnPropertyChanged();
         }
      }
   }

   public string MoveSpeedDayTime
   {
      get => _moveSpeedDayTime;
      set
      {
         if (_moveSpeedDayTime != value)
         {
            _moveSpeedDayTime = value;
            OnPropertyChanged();
         }
      }
   }

   public string MoveSpeedFeral
   {
      get => _moveSpeedFeral;
      set
      {
         if (_moveSpeedFeral != value)
         {
            _moveSpeedFeral = value;
            OnPropertyChanged();
         }
      }
   }

   public string MoveSpeedNightTime
   {
      get => _moveSpeedNightTime;
      set
      {
         if (_moveSpeedNightTime != value)
         {
            _moveSpeedNightTime = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> MoveSpeedOptions { get; } = ["Walk", "Jog", "Run", "Sprint", "Nightmare"];

   public ObservableCollection<string> TrueFalseOptions { get; } = ["True", "False"];

   public void SetMembers(Dictionary<string, string> properties)
   {
      BlockDamage = properties["BlockDamageAI"];
      BlockDamageBloodMoon = properties["BlockDamageAIBM"];
      FeralSenseTimeOfDay = properties["ZombieFeralSense"];
      IsSpawningEnabled = properties["EnemySpawnMode"];
      MaxSpawnedZombies = properties["MaxSpawnedZombies"];
      MoveSpeedBloodMoon = properties["ZombieBMMove"];
      MoveSpeedDayTime = properties["ZombieMove"];
      MoveSpeedFeral = properties["ZombieFeralMove"];
      MoveSpeedNightTime = properties["ZombieMoveNight"];
   }

   private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }
}