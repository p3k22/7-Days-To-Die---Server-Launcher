namespace _7D2D_ServerLauncher.Helpers;

using Microsoft.Win32;

using System.Windows;
using System.Windows.Media;

public static class ControlHelper
{
   /// <summary>
   ///    Recursively retrieves all controls of a specified type within a DependencyObject.
   /// </summary>
   /// <typeparam name="T">The type of control to search for. Must inherit from DependencyObject.</typeparam>
   /// <param name="parent">The parent DependencyObject to search within.</param>
   /// <returns>A list of controls of the specified type found within the parent.</returns>
   public static List<T> GetAllControlsOfType<T>(DependencyObject? parent)
      where T : DependencyObject
   {
      var controls = new List<T>();

      if (parent == null)
      {
         return controls;
      }

      var childCount = VisualTreeHelper.GetChildrenCount(parent);

      for (var i = 0; i < childCount; i++)
      {
         // Get the child DependencyObject at index i
         var child = VisualTreeHelper.GetChild(parent, i);

         // If the child is of type T, add it to the list
         if (child is T control)
         {
            controls.Add(control);
         }

         // Recursively search the child's children
         controls.AddRange(GetAllControlsOfType<T>(child));
      }

      return controls;
   }

   public static string? OpenFolderDialog(string description = "Select a folder")
   {
      var folderDialog = new OpenFolderDialog
                            {
                               Title = description,
                               InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                            };
      return folderDialog.ShowDialog() == true ? folderDialog.FolderName : null;
   }
}