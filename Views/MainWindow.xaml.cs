namespace _7D2D_ServerLauncher.Views;

using _7D2D_ServerLauncher.ViewModels;

using System.IO;
using System.Windows;
using System.Windows.Controls;

/// <summary>
///    Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
   private bool _isAutoDetectingChanges;

   private readonly MainWindowVm _viewModel;

   public MainWindow()
   {
      InitializeComponent();

      _viewModel = new MainWindowVm(this);

      LoadInitialProfileAsync();
   }

   private async void ChangeProfileAsync(int id, bool forceResetFile = false)
   {
      _viewModel.SetSelectedProfileID(id);
      _isAutoDetectingChanges = false;
      ProfileName.Text = _viewModel.GetProfileName(id);

      var profileFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"profile{id}.xml");
      if (File.Exists(profileFilePath) && !forceResetFile)
      {
         await _viewModel.SetDataToAllFields(profileFilePath);
      }
      else
      {
         InitializeViews();
         await Task.Delay(100);
         ConfigManager.WritePropertiesToFile(profileFilePath, _viewModel.GetDataFromAllFields());
      }

      await Task.Delay(100);
      _isAutoDetectingChanges = true;
   }

   private void GlobalComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
   {
      if (!_isAutoDetectingChanges)
      {
         return;
      }

      ConfigManager.WritePropertiesToFile(
      Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"profile{_viewModel.SelectedProfileID}.xml"),
      _viewModel.GetDataFromAllFields());
   }

   private void GlobalIntBox_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
   {
      if (!_isAutoDetectingChanges)
      {
         return;
      }

      ConfigManager.WritePropertiesToFile(
      Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"profile{_viewModel.SelectedProfileID}.xml"),
      _viewModel.GetDataFromAllFields());
   }

   private void GlobalTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
   {
      if (!_isAutoDetectingChanges)
      {
         return;
      }

      ConfigManager.WritePropertiesToFile(
      Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"profile{_viewModel.SelectedProfileID}.xml"),
      _viewModel.GetDataFromAllFields());
   }

   private void InitializeViews()
   {
      ServerConfigPanel.Content = new Server();
      NetworkConfigPanel.Content = new Network();
      SlotConfigPanel.Content = new Slots();
      WebDashConfigPanel.Content = new WebDashboard();
      TelnetConfigPanel.Content = new Telnet();
      DirectoryConfigPanel.Content = new Directory();
      TechnicalConfigPanel.Content = new Technical();
      PerformanceConfigPanel.Content = new Performance();
      WorldConfigPanel.Content = new World();
      DifficultyConfigPanel.Content = new Difficulty();
      PlayerConfigPanel.Content = new Player();
      ZombieConfigPanel.Content = new Zombie();
      BloodMoonConfigPanel.Content = new BloodMoon();
      LootConfigPanel.Content = new Loot();
      LandClaimConfigPanel.Content = new LandClaim();
      TwitchConfigPanel.Content = new Twitch();
   }

   private void LaunchServerButton_OnClick(object sender, RoutedEventArgs e)
   {
      _viewModel.LaunchServer();
   }

   private async void LoadInitialProfileAsync()
   {
      InitializeViews();
      await Task.Delay(100);
      SetCheckBoxProfile(_viewModel.SelectedProfileID);
      ChangeProfileAsync(_viewModel.SelectedProfileID);
   }

   private void ProfileButton_OnClick(object sender, RoutedEventArgs e)
   {
      if (sender is CheckBox checkBox)
      {
         var text = checkBox.Content.ToString();
         var id = int.Parse(text?.Split('#')[1] ?? string.Empty);
         id -= 1;

         SetCheckBoxProfile(id);
         ChangeProfileAsync(id);
      }
   }

   private void ProfileName_OnTextChanged(object sender, TextChangedEventArgs e)
   {
      var tb = sender as TextBox;
      _viewModel.SaveProfileName(_viewModel.SelectedProfileID, tb!.Text);
   }

   private void ResetProfileButton_OnClick(object sender, RoutedEventArgs e)
   {
      ChangeProfileAsync(_viewModel.SelectedProfileID, true);
   }

   private void SetCheckBoxProfile(int id)
   {
      var listOfProfs = new List<CheckBox> {Profile1, Profile2, Profile3, Profile4};
      for (var i = 0; i < listOfProfs.Count; i++)
      {
         listOfProfs[i].IsChecked = i == id;
      }
   }
}