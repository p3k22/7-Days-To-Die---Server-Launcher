namespace _7D2D_ServerLauncher.ViewModels;

public class TwitchViewModel : ViewModelBase
{
   private string _twitchBloodMoonAllowed = "False";

   private string _twitchServerPermission = "90";

   public string TwitchBloodMoonAllowed
   {
      get => _twitchBloodMoonAllowed;
      set
      {
         if (_twitchBloodMoonAllowed != value)
         {
            _twitchBloodMoonAllowed = value;
            SetProperty(nameof(TwitchBloodMoonAllowed), value);
         }
      }
   }

   public string TwitchServerPermission
   {
      get => _twitchServerPermission;
      set
      {
         if (_twitchServerPermission != value)
         {
            _twitchServerPermission = value;
            SetProperty(nameof(TwitchServerPermission), value);
         }
      }
   }
}