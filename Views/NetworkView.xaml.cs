namespace _7D2D_ServerLauncher.Views;

using _7D2D_ServerLauncher.ViewModels;

using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

/// <summary>
///    Interaction logic for NetworkView.xaml
/// </summary>
public partial class NetworkView
{
   public NetworkView()
   {
      InitializeComponent();
      DataContext = new NetworkViewModel();
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
}