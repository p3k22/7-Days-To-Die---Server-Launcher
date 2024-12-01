namespace _7D2D_ServerLauncher.Models;

using _7D2D_ServerLauncher.Helpers;

using System.Diagnostics;

public static class PropertyRegistry
{
   /// <summary>
   ///    A cache of all registered Properties to be saved, edited and loaded
   /// </summary>
   private static readonly Dictionary<string, string> Properties = new Dictionary<string, string>();

   /// <summary>
   ///    Subscribe to be provided notification when registered properties have changed.
   /// </summary>
   public static event Action<string, string> PropertyChanged = null!;

   /// <summary>
   ///    Updates the registered Properties with the values loaded from XML profile.
   ///    Notifies UI updates via subscribers to PropertyChanged.
   /// </summary>
   /// <param name="filePath">File Path of profile.xml (Default = "BaseDirectory\profileX.xml")</param>
   public static void LoadPropertiesFromFile(string filePath)
   {
      var properties = XmlProfileParser.LoadPropertiesFromFile(filePath);
      foreach (var kvp in properties)
      {
         SetProperty(kvp.Key, kvp.Value);
      }
   }

   /// <summary>
   ///    Updates the registered Properties and notifies UI updates via subscribers to PropertyChanged.
   /// </summary>
   /// <param name="name">Name of the property</param>
   /// <param name="value">Value of the property</param>
   public static void SetProperty(string name, string value)
   {
      // Attempt to add property to dict if no entry exists
      if (Properties.TryAdd(name, value))
      {
         // Invoke ui change if successfully added new entry and value to dict
         PropertyChanged?.Invoke(name, value);
         Debug.WriteLine($"Added {name} = {value} to register");
      }
      else
      {
         // If attempt failed (entry already exists) and the new value differs from on in mem,
         // assign new value and invoke ui change, passing new value
         if (Properties[name] != value)
         {
            Properties[name] = value;
            PropertyChanged?.Invoke(name, value);
            Debug.WriteLine($"Updated {name} to {value} in register");
         }
      }
   }

   public static void WritePropertiesToFile(string profileFilePath)
   {
      _ = XmlProfileParser.SavePropertiesToFile(profileFilePath, Properties);
   }
}