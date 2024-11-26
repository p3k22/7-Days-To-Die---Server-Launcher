namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Interfaces;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class NetworkVm : INotifyPropertyChanged, IControlData
{
   private string _address = "";

   private string _disabledProtocols = "SteamNetworking";

   private string _downloadSpeed = "512";

   private string _port = "26900";

   private string _visibility = "Public";

   public event PropertyChangedEventHandler? PropertyChanged;

   public string Address
   {
      get => _address;
      set
      {
         if (_address != value)
         {
            _address = value;
            OnPropertyChanged();
         }
      }
   }

   public string DisabledProtocols
   {
      get => _disabledProtocols;
      set
      {
         if (_disabledProtocols != value)
         {
            _disabledProtocols = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> DisabledProtocolsOptions { get; } =
         ["None", "SteamNetworking", "LiteNetLib", "Both"];

   public string DownloadSpeed
   {
      get => _downloadSpeed;
      set
      {
         if (_downloadSpeed != value)
         {
            _downloadSpeed = value;
            OnPropertyChanged();
         }
      }
   }

   public Dictionary<string, string> GetMembers =>
      new Dictionary<string, string>
         {
            {"ServerIP", _address},
            {"ServerDisabledNetworkProtocols", ProtocolIndexToLabel()},
            {"ServerMaxWorldTransferSpeedKiBs", _downloadSpeed},
            {"ServerPort", _port},
            {"ServerVisibility", VisibilityOptions.IndexOf(_visibility).ToString()}
         };

   public string Port
   {
      get => _port;
      set
      {
         if (_port != value)
         {
            _port = value;
            OnPropertyChanged();
         }
      }
   }

   public string Visibility
   {
      get => _visibility;
      set
      {
         if (_visibility != value)
         {
            _visibility = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> VisibilityOptions { get; } = ["Not Listed", "Friends Only", "Public"];

   public void SetMembers(Dictionary<string, string> properties)
   {
      Address = properties["ServerIP"];
      DisabledProtocols = properties["ServerDisabledNetworkProtocols"];
      DownloadSpeed = properties["ServerMaxWorldTransferSpeedKiBs"];
      Port = properties["ServerPort"];
      Visibility = properties["ServerVisibility"];
   }

   private string ProtocolIndexToLabel()
   {
      var index = DisabledProtocolsOptions.IndexOf(_disabledProtocols);
      switch (index)
      {
         case 0:
            return "";
         case 1:
            return "SteamNetworking";
         case 2:
            return "LiteNetLib";
         case 3:
            return "SteamNetworking, LiteNetLib";
      }

      return "";
   }

   private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }
}