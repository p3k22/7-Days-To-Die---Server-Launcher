namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Interfaces;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class TelnetVm : INotifyPropertyChanged, IControlData
{
   private string _failedLoginBlockTime = "0";

   private string _failedLoginLimit = "0";

   private string _isEnabled = "True";

   private string _isTerminalWindowEnabled = "True";

   private string _password = "";

   private string _port = "8081";

   public event PropertyChangedEventHandler? PropertyChanged;

   public string FailedLoginBlockTime
   {
      get => _failedLoginBlockTime;
      set
      {
         if (_failedLoginBlockTime != value)
         {
            _failedLoginBlockTime = value;
            OnPropertyChanged();
         }
      }
   }

   public string FailedLoginLimit
   {
      get => _failedLoginLimit;
      set
      {
         if (_failedLoginLimit != value)
         {
            _failedLoginLimit = value;
            OnPropertyChanged();
         }
      }
   }

   public Dictionary<string, string> GetMembers =>
      new Dictionary<string, string>
         {
            {"TelnetFailedLoginsBlocktime", _failedLoginBlockTime},
            {"TelnetFailedLoginLimit", _failedLoginLimit},
            {"TelnetEnabled", _isEnabled},
            {"TerminalWindowEnabled", _isTerminalWindowEnabled},
            {"TelnetPassword", _password},
            {"TelnetPort", _port}
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

   public string IsTerminalWindowEnabled
   {
      get => _isTerminalWindowEnabled;
      set
      {
         if (_isTerminalWindowEnabled != value)
         {
            _isTerminalWindowEnabled = value;
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

   public ObservableCollection<string> TerminalWindowEnableOptions { get; } = ["True", "False"];

   public void SetMembers(Dictionary<string, string> properties)
   {
      FailedLoginBlockTime = properties["TelnetFailedLoginsBlocktime"];
      FailedLoginLimit = properties["TelnetFailedLoginLimit"];
      IsEnabled = properties["TelnetEnabled"];
      IsTerminalWindowEnabled = properties["TerminalWindowEnabled"];
      Password = properties["TelnetPassword"];
      Port = properties["TelnetPort"];
   }

   private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }
}