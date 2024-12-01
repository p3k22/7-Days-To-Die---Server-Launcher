namespace _7D2D_ServerLauncher.ViewModels;

public class TelnetViewModel : ViewModelBase
{
   private string _telnetEnabled = "True";

   private string _telnetFailedLoginLimit = "0";

   private string _telnetFailedLoginsBlocktime = "0";

   private string _telnetPassword = "";

   private string _telnetPort = "8081";

   private string _terminalWindowEnabled = "True";

   public string TelnetEnabled
   {
      get => _telnetEnabled;
      set
      {
         if (_telnetEnabled != value)
         {
            _telnetEnabled = value;
            SetProperty(nameof(TelnetEnabled), value);
         }
      }
   }

   public string TelnetFailedLoginLimit
   {
      get => _telnetFailedLoginLimit;
      set
      {
         if (_telnetFailedLoginLimit != value)
         {
            _telnetFailedLoginLimit = value;
            SetProperty(nameof(TelnetFailedLoginLimit), value);
         }
      }
   }

   public string TelnetFailedLoginsBlocktime
   {
      get => _telnetFailedLoginsBlocktime;
      set
      {
         if (_telnetFailedLoginsBlocktime != value)
         {
            _telnetFailedLoginsBlocktime = value;
            SetProperty(nameof(TelnetFailedLoginsBlocktime), value);
         }
      }
   }

   public string TelnetPassword
   {
      get => _telnetPassword;
      set
      {
         if (_telnetPassword != value)
         {
            _telnetPassword = value;
            SetProperty(nameof(TelnetPassword), value);
         }
      }
   }

   public string TelnetPort
   {
      get => _telnetPort;
      set
      {
         if (_telnetPort != value)
         {
            _telnetPort = value;
            SetProperty(nameof(TelnetPort), value);
         }
      }
   }

   public string TerminalWindowEnabled
   {
      get => _terminalWindowEnabled;
      set
      {
         if (_terminalWindowEnabled != value)
         {
            _terminalWindowEnabled = value;
            SetProperty(nameof(TerminalWindowEnabled), value);
         }
      }
   }
}