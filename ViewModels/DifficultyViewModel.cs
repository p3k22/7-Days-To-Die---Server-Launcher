namespace _7D2D_ServerLauncher.ViewModels;

public class DifficultyViewModel : ViewModelBase
{
   private string _buildCreate = "False";

   private string _enemyDifficulty = "Normal";

   private string _gameDifficulty = "Adventurer";

   private string _xpMultiplier = "100";

   public string BuildCreate
   {
      get => _buildCreate;
      set
      {
         if (_buildCreate != value)
         {
            _buildCreate = value;
            SetProperty(nameof(BuildCreate), value);
         }
      }
   }

   public string EnemyDifficulty
   {
      get => _enemyDifficulty;
      set
      {
         if (_enemyDifficulty != value)
         {
            _enemyDifficulty = value;
            SetProperty(nameof(EnemyDifficulty), value);
         }
      }
   }

   public string GameDifficulty
   {
      get => _gameDifficulty;
      set
      {
         if (_gameDifficulty != value)
         {
            _gameDifficulty = value;
            SetProperty(nameof(GameDifficulty), value);
         }
      }
   }

   public string XPMultiplier
   {
      get => _xpMultiplier;
      set
      {
         if (_xpMultiplier != value)
         {
            _xpMultiplier = value;
            SetProperty(nameof(XPMultiplier), value);
         }
      }
   }
}