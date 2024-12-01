namespace _7D2D_ServerLauncher.ViewModels;

public class DirectoryViewModel : ViewModelBase
{
   private string _adminFileName = "serveradmin.xml";

   private string _customDir = "";

   public string AdminFileName
   {
      get => _adminFileName;
      set
      {
         if (_adminFileName != value)
         {
            _adminFileName = value;
            SetProperty(nameof(AdminFileName), value);
         }
      }
   }

   public string UserDataFolder
   {
      get => _customDir;
      set
      {
         if (_customDir != value)
         {
            _customDir = value;
            SetProperty(nameof(UserDataFolder), value);
         }
      }
   }
}