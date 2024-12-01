namespace _7D2D_ServerLauncher.ViewModels;

public class WebDashboardViewModel : ViewModelBase
{
   private string _enableMapRendering = "False";

   private string _webDashboardEnabled = "True";

   private string _webDashboardPort = "8080";

   private string _webDashboardUrl = "";

   public string EnableMapRendering
   {
      get => _enableMapRendering;
      set
      {
         if (_enableMapRendering != value)
         {
            _enableMapRendering = value;
            SetProperty(nameof(EnableMapRendering), value);
         }
      }
   }

   public string WebDashboardEnabled
   {
      get => _webDashboardEnabled;
      set
      {
         if (_webDashboardEnabled != value)
         {
            _webDashboardEnabled = value;
            SetProperty(nameof(WebDashboardEnabled), value);
         }
      }
   }

   public string WebDashboardPort
   {
      get => _webDashboardPort;
      set
      {
         if (_webDashboardPort != value)
         {
            _webDashboardPort = value;
            SetProperty(nameof(WebDashboardPort), value);
         }
      }
   }

   public string WebDashboardUrl
   {
      get => _webDashboardUrl;
      set
      {
         if (_webDashboardUrl != value)
         {
            _webDashboardUrl = value;
            SetProperty(nameof(WebDashboardUrl), value);
         }
      }
   }
}