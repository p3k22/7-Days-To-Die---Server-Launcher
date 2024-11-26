namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Interfaces;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class WebDashboardVm : INotifyPropertyChanged, IControlData
{
   private string _dashboardUrl = "";

   private string _isEnabled = "True";

   private string _isMapRenderingEnabled = "False";

   private string _port = "8080";

   public event PropertyChangedEventHandler? PropertyChanged;

   public string DashboardUrl
   {
      get => _dashboardUrl;
      set
      {
         if (_dashboardUrl != value)
         {
            _dashboardUrl = value;
            OnPropertyChanged();
         }
      }
   }

   public Dictionary<string, string> GetMembers =>
      new Dictionary<string, string>
         {
            {"WebDashboardUrl", _dashboardUrl},
            {"WebDashboardEnabled", _isEnabled},
            {"EnableMapRendering", _isMapRenderingEnabled},
            {"WebDashboardPort", _port}
         };

   public string IsEnabled
   {
      get => _isEnabled;
      set
      {
         if (_isEnabled != value)
         {
            _isEnabled = value;
            OnPropertyChanged();
         }
      }
   }

   public string IsMapRenderingEnabled
   {
      get => _isMapRenderingEnabled;
      set
      {
         if (_isMapRenderingEnabled != value)
         {
            _isMapRenderingEnabled = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> MapRenderingOptions { get; } = ["True", "False"];

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

   public void SetMembers(Dictionary<string, string> properties)
   {
      DashboardUrl = properties["WebDashboardUrl"];
      IsEnabled = properties["WebDashboardEnabled"];
      IsMapRenderingEnabled = properties["EnableMapRendering"];
      Port = properties["WebDashboardPort"];
   }

   private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }
}