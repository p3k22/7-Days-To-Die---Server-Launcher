namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Interfaces;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class DifficultyVm : INotifyPropertyChanged, IControlData
{
   private string _gameDifficulty = "Adventurer";

   private string _isCheatingEnabled = "False";

   private string _xpMod = "100";

   private string _zombieDifficulty = "Normal";

   public event PropertyChangedEventHandler? PropertyChanged;

   public string GameDifficulty
   {
      get => _gameDifficulty;
      set
      {
         if (_gameDifficulty != value)
         {
            _gameDifficulty = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> GameDiffOptions { get; } =
         ["Scavenger", "Adventurer", "Nomad", "Warrior", "Survivalist", "Insane In The Membrane"];

   public Dictionary<string, string> GetMembers =>
      new Dictionary<string, string>
         {
            {"GameDifficulty", GameDiffOptions.IndexOf(_gameDifficulty).ToString()},
            {"BuildCreate", _isCheatingEnabled},
            {"XPMultiplier", _xpMod},
            {"EnemyDifficulty", ZombieDiffOptions.IndexOf(_zombieDifficulty).ToString()}
         };

   public string IsCheatingEnabled
   {
      get => _isCheatingEnabled;
      set
      {
         if (_isCheatingEnabled != value)
         {
            _isCheatingEnabled = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> TrueFalseOptions { get; } = ["True", "False"];

   public string XpMod
   {
      get => _xpMod;
      set
      {
         if (_xpMod != value)
         {
            _xpMod = value;
            OnPropertyChanged();
         }
      }
   }

   public string ZombieDifficulty
   {
      get => _zombieDifficulty;
      set
      {
         if (_zombieDifficulty != value)
         {
            _zombieDifficulty = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> ZombieDiffOptions { get; } = ["Normal", "Feral"];

   public void SetMembers(Dictionary<string, string> properties)
   {
      GameDifficulty = properties["GameDifficulty"];
      IsCheatingEnabled = properties["BuildCreate"];
      XpMod = properties["XPMultiplier"];
      ZombieDifficulty = properties["EnemyDifficulty"];
   }

   private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }
}