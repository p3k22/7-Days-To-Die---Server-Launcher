namespace _7D2D_ServerLauncher.Views;

using _7D2D_ServerLauncher.Helpers;
using _7D2D_ServerLauncher.ViewModels;

using System.Windows;
using System.Windows.Controls;

/// <summary>
///    Interaction logic for MainView.xaml
/// </summary>
public partial class MainView
{
   private MainViewModel? _viewModel;

   private string _idToCopy;

   public MainView()
   {
      InitializeAsync();
   }

   private async Task InitializeViewsAsync()
   {
      ServerConfigPanel.Content = new ServerView();
      NetworkConfigPanel.Content = new NetworkView();
      SlotConfigPanel.Content = new SlotsView();
      WebDashConfigPanel.Content = new WebDashboardView();
      TelnetConfigPanel.Content = new TelnetView();
      DirectoryConfigPanel.Content = new DirectoryView();
      TechnicalConfigPanel.Content = new TechnicalView();
      PerformanceConfigPanel.Content = new PerformanceView();
      WorldConfigPanel.Content = new WorldView();
      DifficultyConfigPanel.Content = new DifficultyView();
      PlayerConfigPanel.Content = new PlayerView();
      ZombieConfigPanel.Content = new ZombieView();
      BloodMoonConfigPanel.Content = new BloodMoonView();
      LootConfigPanel.Content = new LootView();
      LandClaimConfigPanel.Content = new LandClaimView();
      TwitchConfigPanel.Content = new TwitchView();

      // Wait a moment for all views and their view models to initialize.
      await Task.Delay(250);
   }

   private async void InitializeAsync()
   {
      InitializeComponent();
      CopyButton.Visibility = Visibility.Visible;
      PasteButton.Visibility = Visibility.Collapsed;
      await InitializeViewsAsync();
      _viewModel = new MainViewModel([Profile1, Profile2, Profile3, Profile4], ProfileName);
   }

   private void OnButtonClick_LaunchServer(object sender, RoutedEventArgs e)
   {
      if (_viewModel is null)
      {
         return;
      }

      _ = ServerLauncherHelper.LaunchAsync(_viewModel.SelectedProfileID);
   }

   private void OnButtonClick_ResetProfile(object sender, RoutedEventArgs e)
   {
      _ = InitializeViewsAsync();
   }

   private void OnButtonClick_SetProfileID(object sender, RoutedEventArgs e)
   {
      if (sender is CheckBox checkBox)
      {
         var text = checkBox.Content.ToString();
         var id = int.Parse(text?.Split('#')[1] ?? string.Empty);
         id -= 1;

         if (_viewModel is null)
         {
            return;
         }

         _viewModel.SelectedProfileID = id;
      }
   }

   private void OnComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
   {
      _viewModel?.SaveProfile();
   }

   private void OnIntBoxSelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
   {
      _viewModel?.SaveProfile();
   }

   private void OnTextBoxChanged(object sender, TextChangedEventArgs e)
   {
      _viewModel?.SaveProfile();
   }

   private void OnTextBoxChanged_ProfileName(object sender, TextChangedEventArgs e)
   {
      if (_viewModel is null)
      {
         return;
      }

      var tb = sender as TextBox;
      _viewModel.ProfileName = tb!.Text;
   }

   private void OnButtonClick_PasteProfile(object sender, RoutedEventArgs e)
   {
      _viewModel.PasteProfileAsync(_idToCopy);
      CopyButton.Visibility = Visibility.Visible;
      PasteButton.Visibility = Visibility.Collapsed;
   }

   private void OnButtonClick_CopyProfile(object sender, RoutedEventArgs e)
   {
      _idToCopy = _viewModel?.SelectedProfileID.ToString()!;
      CopyButton.Visibility = Visibility.Collapsed;
      PasteButton.Visibility = Visibility.Visible;
   }
}