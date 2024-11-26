namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Interfaces;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class ServerVm : INotifyPropertyChanged, IControlData
{
   private string _description = "A 7 Days to Die server";

   private string _language = "English";

   private string _loginConf;

   private string _name = "My Game Host";

   private string _password;

   private string _region = "Europe";

   private string _webUrl;

   public event PropertyChangedEventHandler? PropertyChanged;

   public string Description
   {
      get => _description;
      set
      {
         if (_description != value)
         {
            _description = value;
            OnPropertyChanged();
         }
      }
   }

   public Dictionary<string, string> GetMembers =>
      new Dictionary<string, string>
         {
            {"ServerDescription", _description},
            {"Language", _language},
            {"ServerLoginConfirmationText", _loginConf},
            {"Region", _region},
            {"ServerName", _name},
            {"ServerPassword", _password},
            {"ServerWebsiteURL", _webUrl}
         };

   public string Language
   {
      get => _language;
      set
      {
         if (_language != value)
         {
            _language = value;
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> LanguageOptions { get; } =
      [
         "English", "Brazilian", "French", "German", "Italian", "Japanese", "Korean", "Polish", "Portuguese", "Russian",
         "Simplified Chinese", "Traditional Chinese", "Turkish"
      ];

   public string LoginConf
   {
      get => _loginConf;
      set
      {
         if (_loginConf != value)
         {
            _loginConf = value;
            OnPropertyChanged();
         }
      }
   }

   public string Name
   {
      get => _name;
      set
      {
         if (_name != value)
         {
            _name = value;
            OnPropertyChanged();
         }
      }
   }

   public string Password
   {
      get => _password;
      set
      {
         if (_password != value)
         {
            _password = value;
            OnPropertyChanged();
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
            OnPropertyChanged();
         }
      }
   }

   public ObservableCollection<string> RegionOptions { get; } =
      [
         "Europe", "North America East", "North America West", "Central America", "South America", "Russia", "Asia",
         "Middle East", "Africa", "Oceania"
      ];

   public string WebUrl
   {
      get => _webUrl;
      set
      {
         if (_webUrl != value)
         {
            _webUrl = value;
            OnPropertyChanged();
         }
      }
   }

   public void SetMembers(Dictionary<string, string> properties)
   {
      Description = properties["ServerDescription"];
      Language = properties["Language"];
      LoginConf = properties["ServerLoginConfirmationText"];
      Region = properties["Region"];
      Name = properties["ServerName"];
      Password = properties["ServerPassword"];
      WebUrl = properties["ServerWebsiteURL"];
   }

   private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }
}