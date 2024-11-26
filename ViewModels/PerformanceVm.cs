namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Interfaces;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class PerformanceVm : INotifyPropertyChanged, IControlData
{
   private string _dmLcBuffer = "3";

   private string _dmMaxItems = "3";

   private string _isDmLcOnly = "True";

   private string _isDynamicMeshEnabled = "True";

   private string _maxMeshLayers = "1000";

   private string _maxViewDistance = "12";

   public event PropertyChangedEventHandler? PropertyChanged;

   public string DmLcBuffer
   {
      get => _dmLcBuffer;
      set
      {
         if (_dmLcBuffer != value)
         {
            _dmLcBuffer = value;
            OnPropertyChanged();
         }
      }
   }

   public string DmMaxItems
   {
      get => _dmMaxItems;
      set
      {
         if (_dmMaxItems != value)
         {
            _dmMaxItems = value;
            OnPropertyChanged();
         }
      }
   }

   public Dictionary<string, string> GetMembers =>
      new Dictionary<string, string>
         {
            {"DynamicMeshLandClaimBuffer", _dmLcBuffer},
            {"DynamicMeshMaxItemCache", _dmMaxItems},
            {"DynamicMeshLandClaimOnly", _isDmLcOnly},
            {"DynamicMeshEnabled", _isDynamicMeshEnabled},
            {"MaxQueuedMeshLayers", _maxMeshLayers},
            {"ServerMaxAllowedViewDistance", _maxViewDistance}
         };

   public string IsDmLcOnly
   {
      get => _isDmLcOnly;
      set
      {
         if (_isDmLcOnly != value)
         {
            _isDmLcOnly = value;
            OnPropertyChanged();
         }
      }
   }

   public string IsDynamicMeshEnabled
   {
      get => _isDynamicMeshEnabled;
      set
      {
         if (_isDynamicMeshEnabled != value)
         {
            _isDynamicMeshEnabled = value;
            OnPropertyChanged();
         }
      }
   }

   public string MaxMeshLayers
   {
      get => _maxMeshLayers;
      set
      {
         if (_maxMeshLayers != value)
         {
            _maxMeshLayers = value;
            OnPropertyChanged();
         }
      }
   }

   public string MaxViewDistance
   {
      get => _maxViewDistance;
      set
      {
         if (_maxViewDistance != value)
         {
            _maxViewDistance = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> TrueFalseOptions { get; } = ["True", "False"];

   public void SetMembers(Dictionary<string, string> properties)
   {
      DmLcBuffer = properties["DynamicMeshLandClaimBuffer"];
      DmMaxItems = properties["DynamicMeshMaxItemCache"];
      IsDmLcOnly = properties["DynamicMeshLandClaimOnly"];
      IsDynamicMeshEnabled = properties["DynamicMeshEnabled"];
      MaxMeshLayers = properties["MaxQueuedMeshLayers"];
      MaxViewDistance = properties["ServerMaxAllowedViewDistance"];
   }

   private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }
}