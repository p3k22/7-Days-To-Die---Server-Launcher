namespace _7D2D_ServerLauncher.ViewModels;

public class PerformanceViewModel : ViewModelBase
{
   private string _dynamicMeshEnabled = "True";

   private string _dynamicMeshLandClaimBuffer = "3";

   private string _dynamicMeshLandClaimOnly = "True";

   private string _dynamicMeshMaxItemCache = "3";

   private string _maxQueuedMeshLayers = "1000";

   private string _serverMaxAllowedViewDistance = "12";

   public string DynamicMeshEnabled
   {
      get => _dynamicMeshEnabled;
      set
      {
         if (_dynamicMeshEnabled != value)
         {
            _dynamicMeshEnabled = value;
            SetProperty(nameof(DynamicMeshEnabled), value);
         }
      }
   }

   public string DynamicMeshLandClaimBuffer
   {
      get => _dynamicMeshLandClaimBuffer;
      set
      {
         if (_dynamicMeshLandClaimBuffer != value)
         {
            _dynamicMeshLandClaimBuffer = value;
            SetProperty(nameof(DynamicMeshLandClaimBuffer), value);
         }
      }
   }

   public string DynamicMeshLandClaimOnly
   {
      get => _dynamicMeshLandClaimOnly;
      set
      {
         if (_dynamicMeshLandClaimOnly != value)
         {
            _dynamicMeshLandClaimOnly = value;
            SetProperty(nameof(DynamicMeshLandClaimOnly), value);
         }
      }
   }

   public string DynamicMeshMaxItemCache
   {
      get => _dynamicMeshMaxItemCache;
      set
      {
         if (_dynamicMeshMaxItemCache != value)
         {
            _dynamicMeshMaxItemCache = value;
            SetProperty(nameof(DynamicMeshMaxItemCache), value);
         }
      }
   }

   public string MaxQueuedMeshLayers
   {
      get => _maxQueuedMeshLayers;
      set
      {
         if (_maxQueuedMeshLayers != value)
         {
            _maxQueuedMeshLayers = value;
            SetProperty(nameof(MaxQueuedMeshLayers), value);
         }
      }
   }

   public string ServerMaxAllowedViewDistance
   {
      get => _serverMaxAllowedViewDistance;
      set
      {
         if (_serverMaxAllowedViewDistance != value)
         {
            _serverMaxAllowedViewDistance = value;
            SetProperty(nameof(ServerMaxAllowedViewDistance), value);
         }
      }
   }
}