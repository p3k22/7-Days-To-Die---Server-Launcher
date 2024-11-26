namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Interfaces;

using System.ComponentModel;
using System.Runtime.CompilerServices;

public class SlotsVm : INotifyPropertyChanged, IControlData
{
   private string _adminPermLvl = "0";

   private string _maxAdmins = "0";

   private string _maxPlayers = "8";

   private string _maxReserved = "0";

   private string _reservedPermLvl = "100";

   public event PropertyChangedEventHandler? PropertyChanged;

   public string AdminPermissionLevel
   {
      get => _adminPermLvl;
      set
      {
         if (_adminPermLvl != value)
         {
            _adminPermLvl = value;
            OnPropertyChanged();
         }
      }
   }

   public Dictionary<string, string> GetMembers =>
      new Dictionary<string, string>
         {
            {"ServerAdminSlotsPermission", _adminPermLvl},
            {"ServerAdminSlots", _maxAdmins},
            {"ServerMaxPlayerCount", _maxPlayers},
            {"ServerReservedSlots", _maxReserved},
            {"ServerReservedSlotsPermission", _reservedPermLvl}
         };

   public string MaxAdmins
   {
      get => _maxAdmins;
      set
      {
         if (_maxAdmins != value)
         {
            _maxAdmins = value;
            OnPropertyChanged();
         }
      }
   }

   public string MaxPlayers
   {
      get => _maxPlayers;
      set
      {
         if (_maxPlayers != value)
         {
            _maxPlayers = value;
            OnPropertyChanged();
         }
      }
   }

   public string MaxReserved
   {
      get => _maxReserved;
      set
      {
         if (_maxReserved != value)
         {
            _maxReserved = value;
            OnPropertyChanged();
         }
      }
   }

   public string ReservedPermissionLevel
   {
      get => _reservedPermLvl;
      set
      {
         if (_reservedPermLvl != value)
         {
            _reservedPermLvl = value;
            OnPropertyChanged();
         }
      }
   }

   public void SetMembers(Dictionary<string, string> properties)
   {
      AdminPermissionLevel = properties["ServerAdminSlotsPermission"];
      MaxAdmins = properties["ServerAdminSlots"];
      MaxPlayers = properties["ServerMaxPlayerCount"];
      MaxReserved = properties["ServerReservedSlots"];
      ReservedPermissionLevel = properties["ServerReservedSlotsPermission"];
   }

   private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }
}