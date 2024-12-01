namespace _7D2D_ServerLauncher.ViewModels;

public class SlotsViewModel : ViewModelBase
{
   private string _serverAdminSlots = "0";

   private string _serverAdminSlotsPermLvl = "0";

   private string _serverMaxPlayerCount = "8";

   private string _serverReservedSlots = "0";

   private string _serverReservedSlotsPermLvl = "100";

   public string ServerAdminSlots
   {
      get => _serverAdminSlots;
      set
      {
         if (_serverAdminSlots != value)
         {
            _serverAdminSlots = value;
            SetProperty(nameof(ServerAdminSlots), value);
         }
      }
   }

   public string ServerAdminSlotsPermission
   {
      get => _serverAdminSlotsPermLvl;
      set
      {
         if (_serverAdminSlotsPermLvl != value)
         {
            _serverAdminSlotsPermLvl = value;
            SetProperty(nameof(ServerAdminSlotsPermission), value);
         }
      }
   }

   public string ServerMaxPlayerCount
   {
      get => _serverMaxPlayerCount;
      set
      {
         if (_serverMaxPlayerCount != value)
         {
            _serverMaxPlayerCount = value;
            SetProperty(nameof(ServerMaxPlayerCount), value);
         }
      }
   }

   public string ServerReservedSlots
   {
      get => _serverReservedSlots;
      set
      {
         if (_serverReservedSlots != value)
         {
            _serverReservedSlots = value;
            SetProperty(nameof(ServerReservedSlots), value);
         }
      }
   }

   public string ServerReservedSlotsPermission
   {
      get => _serverReservedSlotsPermLvl;
      set
      {
         if (_serverReservedSlotsPermLvl != value)
         {
            _serverReservedSlotsPermLvl = value;
            SetProperty(nameof(ServerReservedSlotsPermission), value);
         }
      }
   }
}