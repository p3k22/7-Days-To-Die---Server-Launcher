namespace _7D2D_ServerLauncher.Views;

using _7D2D_ServerLauncher.Helpers;
using _7D2D_ServerLauncher.ViewModels;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using Xceed.Wpf.Toolkit;

/// <summary>
///    Interaction logic for ServerConfig.xaml
/// </summary>
public partial class WebDashboard
{
   public WebDashboard()
   {
      InitializeComponent();
      DataContext = new WebDashboardVm();
      ToggleFieldVisibility(500);
   }

   private void ToggleArrow_Checked(object sender, RoutedEventArgs e)
   {
      // Collapse the border and hide content
      ContentPanel.Visibility = Visibility.Collapsed; // Hide content
      
      ContentBorder.Height = 30; // Set border height to 20

      // Change the arrow to point up
      (ToggleArrow.Content as Path)!.Data = Geometry.Parse("M 0 0 L 10 10 L 20 0 Z"); // Up arrow
   }

   private void ToggleArrow_Unchecked(object sender, RoutedEventArgs e)
   {
      // Expand the border and show content
      ContentPanel.Visibility = Visibility.Visible; // Show content
      ContentBorder.Height = double.NaN; // Reset border height to auto (NaN)

      // Change the arrow to point down
      (ToggleArrow.Content as Path)!.Data = Geometry.Parse("M 0 10 L 10 0 L 20 10 Z"); // Down arrow
   }

   private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
   {
      ToggleFieldVisibility();
   }

   private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
   {
      ToggleFieldVisibility();
   }

   private async void ToggleFieldVisibility(int delay = 0)
   {
      var vm = DataContext as WebDashboardVm;
      var isVisible = vm.IsEnabled == "True";

      await Task.Delay(delay);
      var allTextBoxes = ControlHelper.GetAllControlsOfType<TextBox>(this);
      foreach (var textBox in allTextBoxes)
      {
         textBox.IsEnabled = isVisible;
      }

      var allLabels = ControlHelper.GetAllControlsOfType<Label>(this);
      foreach (var label in allLabels.Where(label => (string) label.Content != "Is Enabled"))
      {
         label.IsEnabled = isVisible;
      }

      var allCombos = ControlHelper.GetAllControlsOfType<ComboBox>(this);
      foreach (var combo in allCombos)
      {
         combo.IsEnabled = isVisible;
      }

      var allIntBoxes = ControlHelper.GetAllControlsOfType<IntegerUpDown>(this);
      foreach (var intBox in allIntBoxes)
      {
         intBox.IsEnabled = isVisible;
      }
   }
}