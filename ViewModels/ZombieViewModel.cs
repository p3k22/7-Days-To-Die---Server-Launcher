namespace _7D2D_ServerLauncher.ViewModels;

public class ZombieViewModel : ViewModelBase
{
   private string _blockDamageAI = "100";

   private string _blockDamageAibm = "100";

   private string _enemySpawnMode = "True";

   private string _maxSpawnedZombies = "64";

   private string _zombieBmMove = "Sprint";

   private string _zombieFeralMove = "Sprint";

   private string _zombieFeralSense = "Off";

   private string _zombieMove = "Walk";

   private string _zombieMoveNight = "Sprint";

   public string BlockDamageAI
   {
      get => _blockDamageAI;
      set
      {
         if (_blockDamageAI != value)
         {
            _blockDamageAI = value;
            SetProperty(nameof(BlockDamageAI), value);
         }
      }
   }

   public string BlockDamageAIBM
   {
      get => _blockDamageAibm;
      set
      {
         if (_blockDamageAibm != value)
         {
            _blockDamageAibm = value;
            SetProperty(nameof(BlockDamageAIBM), value);
         }
      }
   }

   public string EnemySpawnMode
   {
      get => _enemySpawnMode;
      set
      {
         if (_enemySpawnMode != value)
         {
            _enemySpawnMode = value;
            SetProperty(nameof(EnemySpawnMode), value);
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
            SetProperty(nameof(MaxSpawnedZombies), value);
         }
      }
   }

   public string ZombieBMMove
   {
      get => _zombieBmMove;
      set
      {
         if (_zombieBmMove != value)
         {
            _zombieBmMove = value;
            SetProperty(nameof(ZombieBMMove), value);
         }
      }
   }

   public string ZombieFeralMove
   {
      get => _zombieFeralMove;
      set
      {
         if (_zombieFeralMove != value)
         {
            _zombieFeralMove = value;
            SetProperty(nameof(ZombieFeralMove), value);
         }
      }
   }

   public string ZombieFeralSense
   {
      get => _zombieFeralSense;
      set
      {
         if (_zombieFeralSense != value)
         {
            _zombieFeralSense = value;
            SetProperty(nameof(ZombieFeralSense), value);
         }
      }
   }

   public string ZombieMove
   {
      get => _zombieMove;
      set
      {
         if (_zombieMove != value)
         {
            _zombieMove = value;
            SetProperty(nameof(ZombieMove), value);
         }
      }
   }

   public string ZombieMoveNight
   {
      get => _zombieMoveNight;
      set
      {
         if (_zombieMoveNight != value)
         {
            _zombieMoveNight = value;
            SetProperty(nameof(ZombieMoveNight), value);
         }
      }
   }
}