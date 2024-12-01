namespace _7D2D_ServerLauncher.ViewModels;

public class NetworkViewModel : ViewModelBase
{
   private string _serverDisabledNetworkProtocols = "SteamNetworking";

   private string _serverIP = "";

   private string _serverMaxWorldTransferSpeedKiBs = "512";

   private string _serverPort = "26900";

   private string _serverVisibility = "Public";

   public string ServerDisabledNetworkProtocols
   {
      get => _serverDisabledNetworkProtocols;
      set
      {
         if (_serverDisabledNetworkProtocols != value)
         {
            _serverDisabledNetworkProtocols = value;
            SetProperty(nameof(ServerDisabledNetworkProtocols), value);
         }
      }
   }

   public string ServerIP
   {
      get => _serverIP;
      set
      {
         if (_serverIP != value)
         {
            _serverIP = value;
            SetProperty(nameof(ServerIP), value);
         }
      }
   }

   public string ServerMaxWorldTransferSpeedKiBs
   {
      get => _serverMaxWorldTransferSpeedKiBs;
      set
      {
         if (_serverMaxWorldTransferSpeedKiBs != value)
         {
            _serverMaxWorldTransferSpeedKiBs = value;
            SetProperty(nameof(ServerMaxWorldTransferSpeedKiBs), value);
         }
      }
   }

   public string ServerPort
   {
      get => _serverPort;
      set
      {
         if (_serverPort != value)
         {
            _serverPort = value;
            SetProperty(nameof(ServerPort), value);
         }
      }
   }

   public string ServerVisibility
   {
      get => _serverVisibility;
      set
      {
         if (_serverVisibility != value)
         {
            _serverVisibility = value;
            SetProperty(nameof(ServerVisibility), value);
         }
      }
   }
}