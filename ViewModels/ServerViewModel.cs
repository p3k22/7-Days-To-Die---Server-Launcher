namespace _7D2D_ServerLauncher.ViewModels;

public class ServerViewModel : ViewModelBase
{
   private string _language = "English";

   private string _region = "Europe";

   private string _serverDescription = "A 7 Days to Die server";

   private string _serverLoginConfirmationText;

   private string _serverName = "My Game Host";

   private string _serverPassword;

   private string _serverWebsiteURL;

   public string Language
   {
      get => _language;
      set
      {
         if (_language != value)
         {
            _language = value;
            SetProperty(nameof(Language), value);
         }
      }
   }

   public string Region
   {
      get => _region;
      set
      {
         if (_region != value)
         {
            _region = value;
            SetProperty(nameof(Region), value);
         }
      }
   }

   public string ServerDescription
   {
      get => _serverDescription;
      set
      {
         if (_serverDescription != value)
         {
            _serverDescription = value;
            SetProperty(nameof(ServerDescription), value);
         }
      }
   }

   public string ServerLoginConfirmationText
   {
      get => _serverLoginConfirmationText;
      set
      {
         if (_serverLoginConfirmationText != value)
         {
            _serverLoginConfirmationText = value;
            SetProperty(nameof(ServerLoginConfirmationText), value);
         }
      }
   }

   public string ServerName
   {
      get => _serverName;
      set
      {
         if (_serverName != value)
         {
            _serverName = value;
            SetProperty(nameof(ServerName), value);
         }
      }
   }

   public string ServerPassword
   {
      get => _serverPassword;
      set
      {
         if (_serverPassword != value)
         {
            _serverPassword = value;
            SetProperty(nameof(ServerPassword), value);
         }
      }
   }

   public string ServerWebsiteURL
   {
      get => _serverWebsiteURL;
      set
      {
         if (_serverWebsiteURL != value)
         {
            _serverWebsiteURL = value;
            SetProperty(nameof(ServerWebsiteURL), value);
         }
      }
   }
}