namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Helpers;
using _7D2D_ServerLauncher.Models;

using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

public class MainViewModel
{
   private bool _isLoadingProfile; // If true, disables SaveProfile as triggered when overwriting UI fields

   private readonly List<CheckBox> _profileCheckBoxes;

   private readonly TextBox _profileNameTextBox;

   public MainViewModel(List<CheckBox> profileCheckBoxes, TextBox profileNameTextBox)
   {
      // Set global cursor 
      SetCustomCursor();

      // Cache relevant UI
      _profileCheckBoxes = profileCheckBoxes;
      _profileNameTextBox = profileNameTextBox;

      // Create default profile if none exists
      if (!File.Exists(ProfileFilePath("_default")))
      {
         PropertyRegistry.WritePropertiesToFile(ProfileFilePath("_default"));
      }

      // Load last selected profile
      var idFromFile = Configuration.GetValue("selected_prof_id");
      int.TryParse(idFromFile, out var id);
      SelectedProfileID = id;
   }

   /// <summary>
   ///    The Name of the currently selected profile.
   /// </summary>
   public string ProfileName
   {
      get => Configuration.GetValue($"profile_{SelectedProfileID}_name");
      set => Configuration.SetValue($"profile_{SelectedProfileID}_name", value);
   }

   /// <summary>
   ///    The ID of the currently selected profile.
   /// </summary>
   public int SelectedProfileID
   {
      get
      {
         int.TryParse(Configuration.GetValue("selected_prof_id"), out var result);
         return result;
      }
      set
      {
         // Save the value to config
         Configuration.SetValue("selected_prof_id", value.ToString());

         // Load the selected profile properties from disk
         LoadProfileAsync();

         // Highlight the selected profile checkbox
         for (var i = 0; i < _profileCheckBoxes.Count; i++)
         {
            _profileCheckBoxes[i].IsChecked = i == SelectedProfileID;
         }
      }
   }

   public async void PasteProfileAsync(string idToCopy)
   {
      var source = ProfileFilePath(idToCopy);
      var dest = ProfileFilePath(SelectedProfileID.ToString());
      await ServerLauncherHelper.CopyFileAsync(source, dest);
      LoadProfileAsync();
   }

   /// <summary>
   ///    Writes the registered profile properties to disk.
   /// </summary>
   public void SaveProfile()
   {
      // Do not write to disk when loading data from profile files.
      // This is triggered by the UI fields being updated
      if (_isLoadingProfile)
      {
         return;
      }

      PropertyRegistry.WritePropertiesToFile(ProfileFilePath(SelectedProfileID.ToString()));
   }

   /// <summary>
   ///    The location of the profile properties file.
   /// </summary>
   private static string ProfileFilePath(string id)
   {
      return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"profile{id}.xml");
   }

   /// <summary>
   ///    Sets the global mouse cursor to a custom cursor
   /// </summary>
   /// <exception cref="FileNotFoundException"></exception>
   private static void SetCustomCursor()
   {
      var customCursorStream =
         Application.GetResourceStream(new Uri("pack://application:,,,/Cursor/cursor.cur"))?.Stream;

      if (customCursorStream != null)
      {
         using (customCursorStream)
         {
            var customCursor = new Cursor(customCursorStream);

            Mouse.OverrideCursor = customCursor;
         }
      }
      else
      {
         throw new FileNotFoundException("The cursor file could not be found.");
      }
   }

   /// <summary>
   ///    Attempts to load the profile property values stored on disk.
   ///    If no profile is found, the default profile is used.
   /// </summary>
   private async void LoadProfileAsync()
   {
      _isLoadingProfile = true;
      _profileNameTextBox.Text = ProfileName;

      if (File.Exists(ProfileFilePath(SelectedProfileID.ToString())))
      {
         PropertyRegistry.LoadPropertiesFromFile(ProfileFilePath(SelectedProfileID.ToString()));
      }
      else
      {
         // Load the properties from the default profile
         PropertyRegistry.LoadPropertiesFromFile(ProfileFilePath("_default"));

         // Small wait
         await Task.Delay(100);

         // Write these properties to disk as the selected profile properties 
         PropertyRegistry.WritePropertiesToFile(ProfileFilePath(SelectedProfileID.ToString()));
      }

      await Task.Delay(100);
      _isLoadingProfile = false;
   }
}